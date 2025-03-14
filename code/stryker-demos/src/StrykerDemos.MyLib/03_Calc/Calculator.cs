using System.Diagnostics.CodeAnalysis;

namespace StrykerDemos.MyLib._03_Calc;

[SuppressMessage("Style", "IDE0046:Convert to conditional expression")]
public static class Calculator
{
    public static double Add(double a, double b)
    {
        return a + b;
    }

    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    public static double Multiply(double a, double b)
    {
        return a * b;
    }

    public static double? Divide(double a, double b)
    {
        if (b == 0)
        {
            return null;
        }
        
        return a / b;
    }
}