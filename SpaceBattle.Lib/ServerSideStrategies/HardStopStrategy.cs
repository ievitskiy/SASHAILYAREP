using Hwdtech;
using SpaceBattle.Lib.Interfaces;
using SpaceBattle.ServerSide;
using ICommand = SpaceBattle.Lib.Interfaces.ICommand;

namespace SpaceBattle.ServerStrategies
{
    public class HardStopStrategy : IStrategy
    {
        public object StartStrategy(params object[] args)
        {
            var id = args[0];
            var MT = IoC.Resolve<ServerThread>("ServerThreadGetByID", id);
            var sender = IoC.Resolve<IActionSender>("SenderAdapterGetByID", id);
            var hardStopCommand = new ThreadStopper(MT);
            if (args.Length > 1)
            {
                Action act = (Action)args[1];
                var macroHardStopCommand = IoC.Resolve<ICommand>("MacroCommandForHardStopStrategy", hardStopCommand, act);
                return macroHardStopCommand;
            }
            else
            {
                return hardStopCommand;
            }
        }
    }
}
