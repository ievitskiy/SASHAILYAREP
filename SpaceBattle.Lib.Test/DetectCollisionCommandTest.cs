using Hwdtech.Ioc;
using Hwdtech;

using Moq;

namespace SpaceBattle.Lib.Test;

public class DetectCollisionCommandTests
{
    public DetectCollisionCommandTests()
    {
        new InitScopeBasedIoCImplementationCommand().Execute();

        IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();
    }

    [Fact]
    public void SuccesfulDetectCollisionCommandTests()
    {
        new InitScopeBasedIoCImplementationCommand().Execute();
        IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();

        var obj1 = new Mock<IUObject>();
        var obj2 = new Mock<IUObject>();

        var mockCommand = new Mock<SpaceBattle.Lib.ICommand>();
        mockCommand.Setup(x => x.Execute());

        var mockStrategyReturnsCommand = new Mock<IStrategy>();
        mockStrategyReturnsCommand.Setup(x => x.Execute(obj1.Object, obj2.Object)).Returns(mockCommand.Object).Verifiable();

        var mockDict = new Mock<IDictionary<int, object>>();
        mockDict.Setup(d => d.Keys).Returns(new List<int>(){1});

        var mockStrategyReturnsTree = new Mock<IStrategy>();
        mockStrategyReturnsTree.Setup(x => x.Execute()).Returns(mockDict.Object).Verifiable();

        var mockStrategyReturnsList = new Mock<IStrategy>();
        mockStrategyReturnsList.Setup(x => x.Execute(It.IsAny<object[]>())).Returns(new List<int>()).Verifiable();

        var mockStrategyReturnsCorrentList = new Mock<IStrategy>();
        mockStrategyReturnsCorrentList.Setup(x => x.Execute(It.IsAny<object[]>())).Returns(new List<int>()).Verifiable();

        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.GetSolutionTree", (object[] args) => mockStrategyReturnsTree.Object.Execute(args)).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.IUObject.UnionPropertiesForCollision", (object[] args) => mockStrategyReturnsList.Object.Execute(args)).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.Collision", (object[] args) => mockStrategyReturnsCommand.Object.Execute(args)).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.PrepareDataToCollision", (object[] args) => mockStrategyReturnsCorrentList.Object.Execute(args)).Execute();

        ICommand IsCollision = new DetectCollisionCommand(obj1.Object, obj2.Object);

        IsCollision.Execute();
        
        mockStrategyReturnsCorrentList.VerifyAll();
        mockStrategyReturnsCommand.VerifyAll();
        mockStrategyReturnsList.VerifyAll();
        mockStrategyReturnsTree.VerifyAll();
    }

    [Fact]
    public void SuccesfulPrepareDataToCollisionStrategyTest()
    {
        List<int> property1 = new List<int>(){12, 32, 56, 4};
        List<int> property2 = new List<int>(){12, 32, 56, 4};

        IStrategy PrepareData = new PrepareDataToCollisionStrategy();

        Object.Equals(new List<int>(){0, 0, 0, 0}, PrepareData.Execute(property1,property2));
    }
}
