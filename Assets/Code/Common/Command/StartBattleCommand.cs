using Assets.Code.Battle;
using Assets.Code.Common.GemsData;
using Assets.Code.Common.Level;
using Assets.Code.Common.Score;
using Assets.Code.Core;
using Assets.Code.Enemies;
using Assets.Code.Player;
using Assets.Code.UI;
using System.Threading.Tasks;

namespace Assets.Code.Common.Command
{
    public class StartBattleCommand : Command
    {
        public async Task Execute()
        {
            await new ShowScreenFadeCommand().Execute();

            var serviceLocator = ServiceLocator.Instance;
            serviceLocator.GetService<LevelSystem>().SetExperienceValues();
            serviceLocator.GetService<ScoreSystem>().Reset();
            serviceLocator.GetService<GemsSystem>().Reset();
            serviceLocator.GetService<GameStateController>().Reset();
            serviceLocator.GetService<ScoreView>().Reset();
            serviceLocator.GetService<GemsView>().Reset();
            serviceLocator.GetService<PlayerSpawner>().SpawnUserShip();
            serviceLocator.GetService<EnemySpawner>().StartSpawn();

            await new HideScreenFadeCommand().Execute();
        }
    }
}