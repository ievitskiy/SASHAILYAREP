using SpaceBattle.Lib.Interfaces;

namespace SpaceBattle.ServerSide
{
    public class CommandSender : IActionCommand
    {
        private IActionSender sender;
        private IActionCommand command;

        public CommandSender(IActionSender sender, IActionCommand command)
        {
            this.sender = sender;
            this.command = command;
        }

        public void Execute()
        {
            sender.Send(command);
        }
    }
}
