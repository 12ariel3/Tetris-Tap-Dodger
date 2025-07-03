using Assets.Code.Common.Events;
using Assets.Code.Core;
using System;
using System.Threading.Tasks;

namespace Assets.Code.Battle.GameStates
{
    public class PlayingState : GameState, EventObserver
    {
        private Action<GameStateController.GameStates> _onEndedCallback;
        private int _aliveProjectiles;
        private bool _allProjectilesSpawned;
        private bool _gameOverBool;
        private bool _alreadyVictory;

        public void Start(Action<GameStateController.GameStates> onEndedCallback)
        {
            _onEndedCallback = onEndedCallback;
            _aliveProjectiles = 0;
            _allProjectilesSpawned = false;
            _gameOverBool = false;
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.ProjectileDestroyed, this);
            eventQueue.Subscribe(EventIds.ProjectileSpawned, this);
            eventQueue.Subscribe(EventIds.AllProjectilesSpawned, this);
            eventQueue.Subscribe(EventIds.PlayerDestroyed, this);
        }

        public void Stop()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.ProjectileDestroyed, this);
            eventQueue.Unsubscribe(EventIds.ProjectileSpawned, this);
            eventQueue.Unsubscribe(EventIds.AllProjectilesSpawned, this);
            eventQueue.Unsubscribe(EventIds.PlayerDestroyed, this);

        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.PlayerDestroyed)
            {
                _gameOverBool = true;
                _onEndedCallback?.Invoke(GameStateController.GameStates.GameOver);
                return;
            }
            else if (eventData.EventId == EventIds.ProjectileDestroyed)
            {
                if (_aliveProjectiles > 0)
                {
                    _aliveProjectiles--;
                    if (_aliveProjectiles == 1 && _allProjectilesSpawned)
                    {
                        ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.LastProjectileAlive));
                    }
                }
            }
            else if (eventData.EventId == EventIds.ProjectileSpawned)
            {
                _aliveProjectiles += 1;
            }
            else if (eventData.EventId == EventIds.AllProjectilesSpawned)
            {
                _allProjectilesSpawned = true;
            }

            CheckGameState();
        }


        private async void CheckGameState()
        {
            if (_aliveProjectiles == 0 && _allProjectilesSpawned && !_gameOverBool)
            {
                await Task.Delay(800);
                if (!_gameOverBool && !_alreadyVictory)
                {
                    _onEndedCallback?.Invoke(GameStateController.GameStates.Victory);
                    _alreadyVictory = true;
                }
            }
        }
    }
}