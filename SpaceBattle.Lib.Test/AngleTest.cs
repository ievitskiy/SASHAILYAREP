namespace SpaceBattle.Lib.Test;

public class AngleTest
{
    [Fact]
    public void SuccesfullSumOfAngles()
    {
        Angle a = new Angle(45, 1);
        Angle b = new Angle(90, 2);
        Angle c  = a + b;
        Assert.Equal(new Angle(90,1),c);

    }
    
    [Fact]
    public void NotSuccesfullSumOfAngles()
    {
        Angle a = new Angle(45, 1);
        Angle b = new Angle(90, 2);
        Assert.False(a + b == new Angle(90, 2));

    }

    [Fact]
    public void DivizionByZeroException()
    {
        Assert.Throws<Exception>(()=> new Angle(99,0)); 

    }

     [Fact]
    public void SuccesfullComparingHashCode()
    {
        Angle a = new Angle(45, 1);
        Angle b = new Angle(90, 2);
        Assert.True(a.GetHashCode() == b.GetHashCode());
    }
    
       [Fact]
    public void NotSuccesfullComparingHashCode()
    {
        Angle a = new Angle(42, 1);
        Angle b = new Angle(90, 2);
        Assert.True(a.GetHashCode() != b.GetHashCode());
    }
    
    [Fact]
    public void SuccesfullWorkMethodNOD()
    {
        int nod = Angle.NOD(4, 5);
        Assert.Equal(1, nod);
    }
    
    [Fact]
    public void NotSuccesfullEqual()
    {
        Angle a = new Angle(45, 1);
        Angle b = new Angle(90, 2);
        Assert.False(a != b);
    }

    [Fact]
    public void NotEqualObjectsOfDifferentType()
    {
        Angle a = new Angle(45, 1);
        Assert.False(a.Equals("String"));
    }

}
