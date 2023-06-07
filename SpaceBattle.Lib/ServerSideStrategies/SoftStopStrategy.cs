using Hwdtech;
using SpaceBattle.Lib.Interfaces;
using SpaceBattle.ServerSide;
using ICommand = SpaceBattle.Lib.Interfaces.ICommand;

namespace SpaceBattle.ServerStrategies
{
    public class SoftStopStrategy : IStrategy
    {
        public object StartStrategy(params object[] args)
        {
            var id = args[0];
            var MT = IoC.Resolve<ServerThread>("ServerThreadGetByID", id);
            var sender = IoC.Resolve<IActionSender>("SenderAdapterGetByID", id);
            if (args.Length > 1)
            {
                Action act1 = (Action)args[1];
                var softStopCommand = IoC.Resolve<ICommand>("CommandForSoftStopStrategy", MT, act1);
                return softStopCommand;
            }
            else
            {
                var softStopCommand = IoC.Resolve<ICommand>("CommandForSoftStopStrategy", MT);
                return softStopCommand;
            }
        }
    }
}
