using SpaceBattle.Lib.Interfaces;
namespace SpaceBattle.MacroCommand

{
    public class MacroCommands : Lib.Interfaces.ICommand
    {
        IEnumerable<Lib.Interfaces.ICommand> commands;
        public MacroCommands(IEnumerable<Lib.Interfaces.ICommand> commands)
        {
            this.commands = commands;
        }
        public void Execute()
        {
            foreach (Lib.Interfaces.ICommand command in commands)
            {
                command.Execute();
            }
        }
    }
}
