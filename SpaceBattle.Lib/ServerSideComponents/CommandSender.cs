using SpaceBattle.Lib.Interfaces;

namespace SpaceBattle.ServerSide
{
    public class CommandSender : ICommand
    {
        private IActionSender sender;
        private ICommand command;

        public CommandSender(IActionSender sender, ICommand command)
        {
            this.sender = sender;
            this.command = command;
        }

        public void Execute()
        {
            sender.Push(command);
        }
    }
}
