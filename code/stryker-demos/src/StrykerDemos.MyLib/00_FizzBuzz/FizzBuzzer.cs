using System.Diagnostics.CodeAnalysis;
using System.Globalization;
// ReSharper disable ConvertIfStatementToReturnStatement

namespace StrykerDemos.MyLib._00_FizzBuzz;

[SuppressMessage("Style", "IDE0046:Convert to conditional expression")]
public static class FizzBuzzer
{
    public static string FizzBuzz(int number)
    {
        bool isDivisibleBy3 = number % 3 == 0;
        bool isDivisibleBy5 = number % 5 == 0;

        if (isDivisibleBy5 && isDivisibleBy3)
        {
            return "FizzBuzz";
        }

        if (isDivisibleBy3)
        {
            return "Fizz";
        }

        if (isDivisibleBy5)
        {
            return "Buzz";
        }

        return number.ToString(NumberFormatInfo.InvariantInfo);
    }
}