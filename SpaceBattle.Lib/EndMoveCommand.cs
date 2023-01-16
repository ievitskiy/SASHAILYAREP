namespace SpaceBattle.Lib;
using Hwdtech;
public class EndMoveCommand : ICommand
{
    public IMoveCommandEndable obj;
    public EndMoveCommand(IMoveCommandEndable obj)
    {
        this.obj = obj;
    }
    public void Execute()
    {
        IoC.Resolve<ICommand>(
            "Game.Commands.DeleteProperty",
            this.obj.Object,
            "Move"
        ).Execute();

        IoC.Resolve<ICommand>(
            "Game.Commands.Inject",
            this.obj.MoveCommand,
            IoC.Resolve<ICommand>("Game.Commands.Empty")
        ).Execute();
    }
}
