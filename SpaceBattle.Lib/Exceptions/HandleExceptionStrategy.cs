using ICommand = SpaceBattle.Lib.Interfaces.ICommand;
using SpaceBattle.Lib.Interfaces;
using Hwdtech;
using SpaceBattle.ServerSide;

namespace SpaceBattle.Exceptions
{
    public class HandleExceptionStrategy : IStrategy
    {
        public object StartStrategy(params object[] args)
        {
            var exception = (Exception)args[0];
            var command = (ICommand)args[1];

            var dictExceptionHandlers = IoC.Resolve<IDictionary<Exception, Dictionary<ICommand, IStrategy>>>("Dictionary.Handler.Exception");

            if (!dictExceptionHandlers.ContainsKey(exception) || !dictExceptionHandlers[exception].ContainsKey(command))
            {
                var commandData = new Dictionary<string, object>();

                commandData["NoStrategyForCommand"] = command;
                var ex = new Exception();
                ex.Data["Unknown"] = ex;
                throw ex;
            }

            else
            {
                return dictExceptionHandlers[exception][command].StartStrategy();
            }
        }
    }
}
