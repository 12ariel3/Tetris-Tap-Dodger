using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assets.Code.Common.Command
{
    public class CompositeCommand
    {
        private readonly List<Command> _commands;


        public CompositeCommand()
        {
            _commands = new List<Command>();
        }

        public void AddCommand(Command command)
        {
            _commands.Add(command);
        }

        public async Task Execute()
        {
            var tasks = new List<Task>(_commands.Count);
            foreach (var command in _commands)
            {
                var task = command.Execute();
                tasks.Add(task);
            }
            await Task.WhenAll(tasks);
        }
    }
}