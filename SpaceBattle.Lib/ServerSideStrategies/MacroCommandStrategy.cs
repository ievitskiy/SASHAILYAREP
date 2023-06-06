using SpaceBattle.ServerSide;
using SpaceBattle.Lib.Interfaces;
using SpaceBattle.MacroCommand;
using System.Collections.Generic;

namespace SpaceBattle.ServerStrategies
{
    public class MacroCommandForHardStopStrategy: IStrategy
    {
        public object StartStrategy(params object[] args)
        {
            List<Lib.Interfaces.ICommand> commands = new List<Lib.Interfaces.ICommand>();
            var actCommand = new ActionCommand((Action)args[1]);
            var threadStopCommand = (ICommand)args[0];
            commands.Add(threadStopCommand);
            commands.Add(actCommand);
            return new MacroCommands(commands);
        }
    }
}
