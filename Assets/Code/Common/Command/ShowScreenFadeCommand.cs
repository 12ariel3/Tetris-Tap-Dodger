using Assets.Code.Core;
using Assets.Code.ZOthers;
using System.Threading.Tasks;

namespace Assets.Code.Common.Command
{
    public class ShowScreenFadeCommand : Command
    {
        public async Task Execute()
        {
            var serviceLocator = ServiceLocator.Instance;
            serviceLocator.GetService<ScreenFade>().Show();
            await Task.Delay(200);
        }
    }
}