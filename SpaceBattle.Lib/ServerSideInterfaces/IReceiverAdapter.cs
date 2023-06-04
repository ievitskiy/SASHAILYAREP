namespace SpaceBattle.Lib.Interfaces
{
    public interface IReceiverAdapter
    {
        public IActionCommand Receive();
        public bool IsEmpty();
    }
}
