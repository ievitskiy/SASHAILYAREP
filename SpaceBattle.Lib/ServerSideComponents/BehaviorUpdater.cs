using SpaceBattle.Lib.Interfaces;

namespace SpaceBattle.ServerSide
{
    public class UpdateBehaviorCommand : ICommand
    {
        ServerThread updateBehaviorThread;
        Action action;
        public UpdateBehaviorCommand(ServerThread updateBehaviorThread, Action action)
        {
            this.updateBehaviorThread = updateBehaviorThread;
            this.action = action;
        }
        public void Execute()
        {
            if (updateBehaviorThread.Equals(Thread.CurrentThread))
            {
                updateBehaviorThread.UpdateBehavior(action);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
