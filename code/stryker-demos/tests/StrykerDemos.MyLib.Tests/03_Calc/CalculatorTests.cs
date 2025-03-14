using System.Diagnostics.CodeAnalysis;

using StrykerDemos.MyLib._03_Calc;

namespace StrykerDemos.MyLib.Tests._03_Calc;

[SuppressMessage("Style", "IDE0008:Use explicit type")]
public class CalculatorTests
{
    [Fact]
    public void Add()
    {
        var result = Calculator.Add(2, 0);
        
        result.Should().Be(2);
    }

    [Fact]
    public void Subtract()
    {
        var result = Calculator.Subtract(2, 0);
        
        result.Should().Be(2);
    }

    [Fact]
    public void Multiply()
    {
        var result = Calculator.Multiply(1, 1);
        
        result.Should().Be(1);
    }

    [Fact]
    public void Divide()
    {
        var result = Calculator.Divide(1, 1);
        
        result.Should().Be(1);
    }

    [Fact]
    public void Divide_by_zero()
    {
        var result = Calculator.Divide(1, 0);

        result.Should().BeNull("division by zero should fail");
    }
}