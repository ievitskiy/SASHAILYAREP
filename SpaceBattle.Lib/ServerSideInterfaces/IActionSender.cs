namespace SpaceBattle.Lib.Interfaces
{
    public interface IActionSender
    {
        public void Send(IActionCommand command);
    }
}