using System.Threading.Tasks;

namespace Assets.Code.Common.Command
{
    public interface Command
    {
        Task Execute();
    }
}