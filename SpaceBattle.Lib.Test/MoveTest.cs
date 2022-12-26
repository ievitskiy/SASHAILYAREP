namespace SpaceBattle.Lib.Test;
using Moq;
using System;
using Xunit;

public class MoveTest
{
    [Fact]
    public void TestPositiveMoveCommandExecute()
    {
        Mock<IMovable> movableMock = new Mock<IMovable>();
        movableMock.SetupGet<Vector>(m => m.Position).Returns(new Vector(12, 5)).Verifiable();
        movableMock.SetupGet<Vector>(m => m.Velocity).Returns(new Vector(-7, 3)).Verifiable();
        ICommand c = new MoveCommand(movableMock.Object);
        c.Execute();
        movableMock.VerifySet(m => m.Position = new Vector(5, 8));
        movableMock.Verify();
    }

    [Fact]
    public void TestNegativeGetPosition()
    {
        Mock<IMovable> movableMock = new Mock<IMovable>();
        movableMock.SetupGet<Vector>(m=>m.Position).Throws<Exception>().Verifiable();
        movableMock.SetupGet<Vector>(m=>m.Velocity).Returns(new Vector(5, 5)).Verifiable();
        ICommand c = new MoveCommand(movableMock.Object);
        Assert.Throws<Exception>(() => c.Execute());
    }

    [Fact]
    public void TestNegativeGetVelocity()
    {
        Mock<IMovable> movableMock = new Mock<IMovable>();
        movableMock.SetupGet<Vector>(m=>m.Position).Returns(new Vector(5, 5)).Verifiable();
        movableMock.SetupGet<Vector>(m=>m.Velocity).Throws<Exception>().Verifiable();
        ICommand c = new MoveCommand(movableMock.Object);
        Assert.Throws<Exception>(() => c.Execute());
    }

    [Fact]
    public void TestNegativeSetPosition()
    {
        Mock<IMovable> movableMock = new Mock<IMovable>();
        movableMock.SetupGet<Vector>(m => m.Position).Returns(new Vector(12, 5)).Verifiable();
        movableMock.SetupGet<Vector>(m => m.Velocity).Returns(new Vector(-7, 3)).Verifiable();
        movableMock.SetupSet(m => m.Position = It.IsAny<Vector>()).Throws<Exception>();
        ICommand c = new MoveCommand(movableMock.Object);
        Assert.Throws<Exception>(() => c.Execute());
    }
}
