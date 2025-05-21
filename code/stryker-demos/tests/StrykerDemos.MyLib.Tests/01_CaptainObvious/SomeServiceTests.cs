using System.Diagnostics.CodeAnalysis;

using StrykerDemos.MyLib._01_CaptainObvious;

namespace StrykerDemos.MyLib.Tests._01_CaptainObvious;

[SuppressMessage("Style", "IDE0008:Use explicit type")]
[SuppressMessage("Style", "IDE0058:Expression value is never used")]
public class SomeServiceTests
{
    [Fact]
    public void Given_below_baseline_number_returns_true()
    {
        const int baseLine = 5;
        const int belowBaseLineNumber = 3;
        var sut = new SomeService(baseLine);

        sut
            .IsSmallerThanBaseline(belowBaseLineNumber)
            .Should()
            .BeTrue("3 is smaller than 5");
    }
    
    [Fact]
    public void Given_above_baseline_number_returns_false()
    {
        const int baseLine = 5;
        const int belowBaseLineNumber = 8;
        var sut = new SomeService(baseLine);

        sut
            .IsSmallerThanBaseline(belowBaseLineNumber)
            .Should()
            .BeFalse("8 is larger than 5");
    }

    [Theory]
    [InlineData(10, "child")]
    [InlineData(20, "adult")]
    public void DoMagic_works(int input, string expected)
    {
        SomeService.DoMagic(input).Should().Be(expected);
    }
}