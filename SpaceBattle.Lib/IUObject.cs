namespace SpaceBattle.Lib;

public interface IUObject{
    object getProperty(string key);
    void SetProperty(string key, object val);
}
