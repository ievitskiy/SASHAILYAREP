namespace SpaceBattle.Lib.Test;
using Moq;
using System;
using Xunit;

public class VectorTest
{
    [Fact]
    public void TestPositiveVectorOperatorPlus()
    {
        Vector v1 = new Vector(1, 2);
        Vector v2 = new Vector(3, 4);
        Assert.Equal(new Vector(4, 6), v1 + v2);
    }

    [Fact]
    public void TestNegativeVectorOperatorPlusDifferentSizeOfVectors()
    {
        Vector v1 = new Vector(1, 0, 0);
        Vector v2 = new Vector(1, 0);
        Assert.Throws<ArgumentException>(() => v1 + v2);
    }

    [Fact]
    public void TestPositiveVectorOperatorMinus()
    {
        Vector v1 = new Vector(1, 2);
        Vector v2 = new Vector(3, 4);
        Assert.Equal(new Vector(-2, -2), v1 - v2);
    }

    [Fact]
    public void TestNegativeVectorOperatorMinusDifferentSizeOfVectors()
    {
        Vector v1 = new Vector(1, 0, 0);
        Vector v2 = new Vector(1, 0);
        Assert.Throws<ArgumentException>(() => v1 - v2);
    }

    [Fact]
    public void TestPositiveVectorOperatorEquality()
    {
        Vector v1 = new Vector(1, 2);
        Vector v2 = new Vector(1, 2);
        Assert.True(v1==v2);
    }

    [Fact]
    public void TestNegativeVectorOperatorEqualityDifferntValues()
    {
        Vector v1 = new Vector(1, 2);
        Vector v2 = new Vector(3, 4);
        Assert.False(v1==v2);
    }

    [Fact]
    public void TestNegativeVectorOperatorEqualityDifferentSizeOfVectors()
    {
        Vector v1 = new Vector(1, 2);
        Vector v2 = new Vector(3, 4, 5);
        Assert.False(v1==v2);
    }

    [Fact]
    public void TestPositiveVectorOperatorNotEquality()
    {
        Vector v1 = new Vector(1, 2);
        Vector v2 = new Vector(3, 4);
        Assert.True(v1!=v2);
    }
    
    [Fact]
    public void TestNegativeVectorOperatorNotEqualitySameValues()
    {
        Vector v1 = new Vector(1, 2);
        Vector v2 = new Vector(1, 2);
        Assert.False(v1!=v2);
    }

    [Fact]
    public void TestPositiveEquals()
    {
        Vector v1 = new Vector(1, 2);
        Assert.True(v1.Equals(new Vector(1, 2)));
    }

    [Fact]
    public void TestNegativeEqualsDifferentValues()
    {
        Vector v1 = new Vector(1, 2);
        Assert.False(v1.Equals(new Vector(2, 3)));
    }

    [Fact]
    public void TestNegativeEqualsDifferentTypes()
    {
        Vector v1 = new Vector(1, 2);
        int n = 1;
        Assert.False(v1.Equals(n));
    }

    [Fact]
    public void TestGetHashCode()
    {
        Vector v1 = new Vector(1, 1);
        Vector v2 = new Vector(1, 1);
        
        Assert.Equal(v1.GetHashCode(),v2.GetHashCode());
    }
}
