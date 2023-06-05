using SpaceBattle.Lib.Interfaces;
using SpaceBattle.ServerSide;

namespace SpaceBattle.ServerStrategies
{
    public class CommandForSoftStopStrategy : IStrategy
    {
        public object StartStrategy(params object[] args)
        {
            var MT = (ServerThread)args[0];
            {
                Action act = new Action(() =>
                {
                    if (!MT.QueueIsEmpty())
                    {
                        MT.CommandHandler();
                    }
                    else
                    {
                        new ThreadStopper(MT).Execute();
                        if (args.Length > 1)
                        {
                            Action act1 = (Action)args[1];
                            act1();
                        }
                    }
                });
                return new UpdateBehaviorCommand((ServerThread)args[0], act);
            }
        }
    }
}
