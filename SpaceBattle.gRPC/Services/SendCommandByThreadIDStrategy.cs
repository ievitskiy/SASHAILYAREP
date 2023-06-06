using Hwdtech;
using SpaceBattle.Lib.Interfaces;
using SpaceBattle.ServerSide;
using ICommand = SpaceBattle.Lib.Interfaces.ICommand;

namespace SpaceBattle.gRPC.Services
{
    public class SendCommandByThreadIDStrategy : IStrategy
    {
        public object StartStrategy(params object[] args)
        {
            var sender = IoC.Resolve<IActionSender>("SenderAdapterGetByID", args[0]);
            var sendCommand = new CommandSender(sender, (ICommand)args[1]);
            return sendCommand;
        }
    }
}

