namespace SpaceBattle.Lib.Interfaces
{
    public interface IReceiverAdapter
    {
        public ICommand Receive();
        public bool IsEmpty();
    }
}
