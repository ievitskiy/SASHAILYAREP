using SpaceBattle.Lib.Interfaces;

namespace SpaceBattle.ServerSide
{
    public class ActionCommand : IActionCommand
    {
        private Action action;

        public ActionCommand(Action action)
        {
            this.action = action;
        }

        public void Execute()
        {
            action();
        }
    }
}
