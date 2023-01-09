namespace SpaceBattle.Lib;

public class Angle
{
    public int Numerator { get; set; }
    public int Denominator { get; set; }

    public Angle(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new Exception();
        }

        int gcd = GCD(numerator,denominator);
        this.Numerator = numerator / gcd;
        this.Denominator = denominator / gcd;
    }
    public static int GCD(int x,int y)
    {
        while (x != y)
            {
                if (x > y)
                    x = x - y;
                else
                    y = y - x;
            }
            return x;
    }
    
    public static Angle operator +(Angle a, Angle b)
    {
        int num = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
        int den = a.Denominator * b.Denominator;
        int gcd = GCD(num, den);
        return new Angle(num/gcd , den/gcd);
    }

    public static bool operator ==(Angle a, Angle b) => (a.Numerator == b.Numerator) && (a.Denominator == b.Denominator);

    public static bool operator !=(Angle a, Angle b) => !(a == b);

    public override bool Equals(object? obj) => obj is Angle a && this.Numerator == a.Numerator && this.Denominator == a.Denominator;

    public override int GetHashCode() => ((this.Numerator + this.Denominator).ToString() ).GetHashCode();
}
