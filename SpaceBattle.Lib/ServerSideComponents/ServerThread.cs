using SpaceBattle.Lib.Interfaces;
using Hwdtech;

namespace SpaceBattle.ServerSide
{
    public class ServerThread
    {
        public ServerThread(IReceiverAdapter queue)
        {
            this.queue = queue;
            strategy = new Action(() =>
            {
                CommandHandler();
            });
            this.thread = new Thread(() =>
            {
                while (!stop)
                {
                    strategy.Invoke();
                }
            });
        }
        internal bool stop = false;
        private IReceiverAdapter queue;
        private Thread thread;
        private Action strategy;
        public void Stop()
        {
            stop = true;
        }
        public void Execute()
        {
            thread.Start();
        }
        internal void CommandHandler()
        {
            SpaceBattle.Lib.Interfaces.ICommand command = this.queue.Receive();
            try
            {
                command.Execute();
            }
            catch (Exception e)
            {
                var exceptionCommand = IoC.Resolve<SpaceBattle.Lib.Interfaces.ICommand>("HandleException", e, command);
                exceptionCommand.Execute();
            }
        }
        public void UpdateBehavior(Action newBehavior)
        {
            strategy = newBehavior;
        }
        public bool GetStop()
        {
            return this.stop;
        }
        public bool QueueIsEmpty()
        {
            return queue.IsEmpty();
        }
        public bool Equals(Thread thread)
        {
            return this.thread == thread;
        }
    }
}
