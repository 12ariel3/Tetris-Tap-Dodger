using Assets.Code.Common.Events;
using Assets.Code.Core.DataStorage;
using Assets.Code.Core;
using Assets.Code.UI;

namespace Assets.Code.Common.Score
{
    public class ScoreSystemImpl : EventObserver, ScoreSystem
    {
        private readonly DataStore _dataStore;
        private int _battleCurrentScore;
        private int _totalScore;
        private const string UserData = "UserData";

        public int BattleCurrentScore => _battleCurrentScore;


        public ScoreSystemImpl(DataStore dataStore)
        {
            _dataStore = dataStore;
            _totalScore = GetTotalScore();
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.ReturnToMainMenu, this);
            eventQueue.Subscribe(EventIds.ProjectileDestroyed, this);
            eventQueue.Subscribe(EventIds.VictorySpinWheelSendFinalValues, this);
        }

        public void Reset()
        {
            _battleCurrentScore = 0;
        }

        public void ShowTotalScore()
        {
            ServiceLocator.Instance.GetService<ScoreView>().UpdateScore(_totalScore);
        }


        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.ReturnToMainMenu)
            {
                _totalScore += _battleCurrentScore;
                SaveTotalScore(_totalScore);
                return;
            }


            if (eventData.EventId == EventIds.ProjectileDestroyed)
            {
                var projectileDestroyedEventData = (ProjectileDestroyedEventData)eventData;
                AddScore(projectileDestroyedEventData);

                return;
            }

            if (eventData.EventId == EventIds.VictorySpinWheelSendFinalValues)
            {
                var victorySpinWheelSendEventData = (VictorySpinWheelSendEventData)eventData;
                _battleCurrentScore = victorySpinWheelSendEventData.BattleFinalScore;
                return;
            }
        }


        private void AddScore(ProjectileDestroyedEventData projectileDestroyedEventData)
        {
            _battleCurrentScore += projectileDestroyedEventData.ScoreToAdd;
            ServiceLocator.Instance.GetService<ScoreView>().UpdateScore(_battleCurrentScore);
        }


        public void SaveTotalScore(int totalScore)
        {
            _totalScore = totalScore;
            var userData = new UserData { TotalScore = totalScore };
            _dataStore.SetData(userData, UserData);
        }


        public int GetTotalScore()
        {
            var userData = _dataStore.GetData<UserData>(UserData)
                        ?? new UserData();
            return userData.TotalScore;
        }
    }
}