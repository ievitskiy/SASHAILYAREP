using SpaceBattle.Lib.Interfaces;
using System.Collections.Concurrent;

namespace SpaceBattle.ServerSide
{
    public class ReceiverAdapter: IReceiverAdapter
    {
        BlockingCollection<ICommand> inputCommands;
        public ReceiverAdapter(BlockingCollection<ICommand> inputCommands)
        {
            this.inputCommands = inputCommands;
        }
        public ICommand Receive()
        {
            return inputCommands.Take();
        }

        public bool IsEmpty()
        {
            return inputCommands.Count() == 0;
        }
    }
}
