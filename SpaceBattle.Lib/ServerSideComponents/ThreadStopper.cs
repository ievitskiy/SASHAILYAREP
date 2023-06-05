using SpaceBattle.Lib.Interfaces;

namespace SpaceBattle.ServerSide
{
    public class ThreadStopper : ICommand
    {
        ServerThread stoppingThread;
        public ThreadStopper(ServerThread stoppingThread)
        {
            this.stoppingThread = stoppingThread;
        }
        public void Execute()
        {
            if (stoppingThread.Equals(Thread.CurrentThread))
            {
                stoppingThread.Stop();
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
