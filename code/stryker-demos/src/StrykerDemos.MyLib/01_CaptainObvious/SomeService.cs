using System.Diagnostics.CodeAnalysis;

namespace StrykerDemos.MyLib._01_CaptainObvious;

[SuppressMessage("Style", "IDE0022:Use block body for method")]
public class SomeService(int baseLine)
{
    private int BaseLine { get; } = baseLine;

    public bool IsSmallerThanBaseline(int number)
    {
        return number < BaseLine;
    }

    public static string DoMagic(int i) => i < 18 ? "child" : "adult";
}