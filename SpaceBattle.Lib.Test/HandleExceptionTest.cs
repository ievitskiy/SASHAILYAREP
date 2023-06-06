using Hwdtech.Ioc;
using Hwdtech;
using SpaceBattle.Lib.Interfaces;
using System.Collections.Concurrent;
using ICommand = SpaceBattle.Lib.Interfaces.ICommand;
using SpaceBattle.Exceptions;
using Moq;
using SpaceBattle.ServerSide;

namespace SpaceBattle.Lib.Test
{
    public class HandleExceptionTest
    {
        public HandleExceptionTest()
        {
            new InitScopeBasedIoCImplementationCommand().Execute();
            IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();
            var exceptionCommandStrategyDictionary = new Dictionary<Exception, Dictionary<SpaceBattle.Lib.Interfaces.ICommand, IStrategy>>();
            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Dictionary.Handler.Exception", (object[] args) => { return exceptionCommandStrategyDictionary; }).Execute();
        }
        [Fact]
        public void HandlExceptionFindTest()
        {
            var exceptionCommandStrategyDictionary = IoC.Resolve<Dictionary<Exception, Dictionary<SpaceBattle.Lib.Interfaces.ICommand, IStrategy>>>("Dictionary.Handler.Exception");
            var commandStrategyDictionary = new Dictionary<SpaceBattle.Lib.Interfaces.ICommand, IStrategy>();

            var keyCommand = new ActionCommand(() => { });
            var mockCommand = new Mock<SpaceBattle.Lib.Interfaces.ICommand>();
            mockCommand.Setup(_command => _command.Execute());
            var mockStrategy = new Mock<IStrategy>();
            mockStrategy.Setup(_strategy => _strategy.StartStrategy(It.IsAny<object[]>())).Returns(mockCommand.Object).Verifiable();
            commandStrategyDictionary.TryAdd(keyCommand, mockStrategy.Object);

            var exception = new ArgumentException();
            exceptionCommandStrategyDictionary.TryAdd(exception, commandStrategyDictionary);

            var handleExceptionStrategy = new HandleExceptionStrategy();
            var exceptionHandlerCommand = handleExceptionStrategy.StartStrategy(exception, keyCommand);
            mockStrategy.Verify();
        }
        [Fact]
        public void HandleExceptionNotFindTest()
        {
            var exceptionCommandStrategyDictionary = IoC.Resolve<Dictionary<Exception, Dictionary<SpaceBattle.Lib.Interfaces.ICommand, IStrategy>>>("Dictionary.Handler.Exception");
            var commandStrategyDictionary = new Dictionary<SpaceBattle.Lib.Interfaces.ICommand, IStrategy>();

            var keyCommand = new ActionCommand(() => { });
            var mockCommand = new Mock<SpaceBattle.Lib.Interfaces.ICommand>();
            mockCommand.Setup(_command => _command.Execute());
            var mockStrategy = new Mock<IStrategy>();
            mockStrategy.Setup(_strategy => _strategy.StartStrategy(It.IsAny<object[]>())).Returns(mockCommand.Object).Verifiable();
            commandStrategyDictionary.TryAdd(keyCommand, mockStrategy.Object);

            var exception = new ArgumentException();
            exceptionCommandStrategyDictionary.TryAdd(exception, commandStrategyDictionary);

            var falseException = new InvalidOperationException();
            var handleExceptionStrategy = new HandleExceptionStrategy();
            Assert.Throws<Exception>(() => { handleExceptionStrategy.StartStrategy(falseException, keyCommand); });
        }
    }
}
