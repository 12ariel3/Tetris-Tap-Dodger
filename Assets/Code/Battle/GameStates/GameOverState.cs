using Assets.Code.Common.Command;
using Assets.Code.Common.Events;
using Assets.Code.Core;
using System;

namespace Assets.Code.Battle.GameStates
{
    public class GameOverState : GameState
    {
        private readonly Command _stopBattleCommand;

        public GameOverState(Command stopBattleCommand)
        {
            _stopBattleCommand = stopBattleCommand;
        }

        public void Start(Action<GameStateController.GameStates> onEndedCallback)
        {
            ServiceLocator.Instance.GetService<CommandQueue>().AddCommand(_stopBattleCommand);
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.GameOver));
        }

        public void Stop()
        {
        }
    }
}