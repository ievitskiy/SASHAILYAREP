using SpaceBattle.Lib.Interfaces;
using SpaceBattle.ServerSide;
using System.Collections.Concurrent;

namespace SpaceBattle.ServerStrategies
{
    public class CreateReceiverAdapterStrategy : IStrategy
    {
        public object StartStrategy(params object[] args)
        {
            var commands = (BlockingCollection<ICommand>)args[0];
            if (args.Length > 1)
            {
                commands.Append(new ActionCommand((Action)args[1]));
            }
            IReceiverAdapter queue = new ReceiverAdapter(commands);
            return queue;
        }
    }
}
