using SpaceBattle.Lib.Interfaces;
using System.Collections.Concurrent;

namespace SpaceBattle.ServerSide
{
    public class SenderAdapter : IActionSender
    {
        BlockingCollection<ICommand> queue;
        public SenderAdapter(BlockingCollection<ICommand> queue)
        {
            this.queue = queue;
        }
        public void Push(ICommand command)
        {
            queue.Add(command);
        }
    }
}
