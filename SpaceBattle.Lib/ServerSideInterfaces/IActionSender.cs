namespace SpaceBattle.Lib.Interfaces
{
    public interface IActionSender
    {
        public void Push(IActionCommand command);
    }
}