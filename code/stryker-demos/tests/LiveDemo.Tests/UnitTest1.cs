using System.Diagnostics.CodeAnalysis;

namespace LiveDemo.Tests;

[SuppressMessage("Style", "IDE0058:Expression value is never used")]
public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        true.Should().BeTrue();
    }
}