using Assets.Code.Core;
using Assets.Code.Enemies;
using System.Threading.Tasks;

namespace Assets.Code.Common.Command
{
    public class StopBattleCommand : Command
    {
        public Task Execute()
        {
            var serviceLocator = ServiceLocator.Instance;
            serviceLocator.GetService<EnemySpawner>().Stop();
            return Task.CompletedTask;
        }
    }
}