using System.Diagnostics.CodeAnalysis;

using StrykerDemos.MyLib._05_Misc;

namespace StrykerDemos.MyLib.Tests._05_Misc;

[SuppressMessage("Style", "IDE0022:Use block body for method")]
public class MiscTests
{
    [Theory]
    [InlineData("foo", true)]
    // [InlineData("! 👉", false)]
    public void DoRegexMagic_works(string input, bool expected) => 
        Misc.DoRegexMagic(input).Should().Be(expected);

    [Fact]
    public void DoMathMagic_works() => 
        Misc.DoMathMagic(2.00m).Should().Be(2m);
}