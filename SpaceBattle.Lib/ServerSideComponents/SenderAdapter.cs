using SpaceBattle.Lib.Interfaces;
using System.Collections.Concurrent;

namespace SpaceBattle.ServerSide
{
    public class SenderAdapter : IActionSender
    {
        BlockingCollection<IActionCommand> queue;
        public SenderAdapter(BlockingCollection<IActionCommand> queue)
        {
            this.queue = queue;
        }
        public void Push(IActionCommand command)
        {
            queue.Add(command);
        }
    }
}
