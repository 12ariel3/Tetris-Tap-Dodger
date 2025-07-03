using Assets.Code.Core;
using Assets.Code.ZOthers;
using System.Threading.Tasks;

namespace Assets.Code.Common.Command
{
    public class HideScreenFadeCommand : Command
    {
        public async Task Execute()
        {
            var serviceLocator = ServiceLocator.Instance;
            serviceLocator.GetService<ScreenFade>().Hide();
            await Task.Delay(200);
        }
    }
}