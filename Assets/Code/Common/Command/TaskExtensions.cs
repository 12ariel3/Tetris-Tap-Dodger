using System.Collections;
using System.Threading.Tasks;

namespace Assets.Code.Common.Command
{
    public static class TaskExtensions
    {
        public static async void WrapErrors(this Task task)
        {
            await task;
        }

        public static IEnumerator AsCoroutine(this Task task)
        {
            while (!task.IsCompleted)
            {
                yield return null;
            }
            if (task.IsFaulted)
            {
                throw task.Exception;
            }
        }
    }
}