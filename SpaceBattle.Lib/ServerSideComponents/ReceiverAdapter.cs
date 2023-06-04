using SpaceBattle.Lib.Interfaces;
using System.Collections.Concurrent;

namespace SpaceBattle.ServerSide
{
    public class ReceiverAdapter: IReceiverAdapter
    {
        BlockingCollection<IActionCommand> inputCommands;
        public ReceiverAdapter(BlockingCollection<IActionCommand> inputCommands)
        {
            this.inputCommands = inputCommands;
        }
        public IActionCommand Receive()
        {
            return inputCommands.Take();
        }

        public bool IsEmpty()
        {
            return inputCommands.Count() == 0;
        }
    }
}
