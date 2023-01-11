namespace SpaceBattle.Lib;

public interface IMoveCommandEndable
{
    IUObject Object { get; }
    ICommand MoveCommand { get; }
    IQueue<ICommand> Queue { get; }
}
