using Hwdtech;
using SpaceBattle.Lib.Interfaces;
using SpaceBattle.ServerSide;
using System.Collections.Concurrent;

namespace SpaceBattle.ServerStrategies
{
    public class CreateAndStartThreadStrategy : IStrategy
    {
        public object StartStrategy(params object[] args)
        {
            var senderDict = IoC.Resolve<ConcurrentDictionary<string, IActionSender>>("ThreadIDSenderMapping");
            senderDict.TryAdd((string)args[0], (IActionSender)args[1]);
            var MT = new ServerThread((IReceiverAdapter)args[2]);
            MT.Execute();
            var threadDict = IoC.Resolve<ConcurrentDictionary<string, ServerThread>>("ThreadIDMyThreadMapping");
            threadDict.TryAdd((string)args[0], MT);
            return MT;
        }
    }
}
