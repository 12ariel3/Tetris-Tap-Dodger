using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Common.Command
{
    public class PauseGameCommand : Command
    {
        public Task Execute()
        {
            Time.timeScale = 0;
            return Task.CompletedTask;
        }
    }
}