namespace SpaceBattle.Lib.Interfaces
{
    public interface IActionSender
    {
        public void Push(ICommand command);
    }
}