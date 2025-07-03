using System.Threading.Tasks;

namespace Assets.Code.Common.Command
{
    public class LoadGameSceneCommand : Command
    {
        public async Task Execute()
        {
            await new LoadSceneCommand("Game").Execute();
            await new StartBattleCommand().Execute(); ;
        }
    }
}