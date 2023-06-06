namespace SpaceBattleGrpc.Others;

using SpaceBattle.Lib.Interfaces;

public class StartEndPointServiceStrategy : IStrategy
{
    public object StartStrategy(params object[] args)
    {
        return new StartEndPointServiceCommand();
    }
}
