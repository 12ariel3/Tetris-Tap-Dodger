using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Common.Command
{
    public class ResumeGameCommand : Command
    {
        public Task Execute()
        {
            Time.timeScale = 1;
            return Task.CompletedTask;
        }
    }
}