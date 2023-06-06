using SpaceBattle.Lib.Interfaces;
using SpaceBattle.ServerSide;

namespace SpaceBattle.ServerStrategies
{
    public class SendCommandStrategy: IStrategy
    {
        public object StartStrategy(params object[] args)
        {
            var sendCommand = new CommandSender((IActionSender)args[0], (ICommand)args[1]);
            return sendCommand;
        }
    }
}
