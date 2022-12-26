namespace SpaceBattle.Lib;
using Angle;

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
