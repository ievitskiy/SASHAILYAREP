namespace SpaceBattle.Lib;
using Angles

public interface IRotatable
{
    Angle Angle
    {
        get;
        set;
    }
    Angle AngularVelocity
    {
        get;
    }
}
