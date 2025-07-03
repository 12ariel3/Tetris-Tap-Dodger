using Assets.Code.Battle;
using Assets.Code.Common.Events;
using Assets.Code.Core;
using Assets.Code.Enemies;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Common.Command
{
    public class ContinueBattleCommand : Command
    {
        public async Task Execute()
        {
            await new ShowScreenFadeCommand().Execute();

            var serviceLocator = ServiceLocator.Instance;
            var continueBattleAfterAds = new EventData(EventIds.ContinueBattleAfterAds);
            serviceLocator.GetService<EventQueue>().EnqueueEvent(continueBattleAfterAds);
            serviceLocator.GetService<GameStateController>().Reset();
            serviceLocator.GetService<EnemySpawner>().RestartSpawn();

            await new HideScreenFadeCommand().Execute();
        }
    }
}