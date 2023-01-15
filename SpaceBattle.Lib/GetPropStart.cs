namespace SpaceBattle.Lib;
public class GetPropertyStrategy : IStrategy
{
    public object Execute(params object[] args)
    {
        string property = (string)args[0];
        IUObject obj = (IUObject)args[1];
        return obj.getProperty(property);
    }
}
