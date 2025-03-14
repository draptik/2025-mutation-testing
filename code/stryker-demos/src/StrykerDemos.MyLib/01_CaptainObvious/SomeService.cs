namespace StrykerDemos.MyLib._01_CaptainObvious;

public class SomeService(int baseLine)
{
    private int BaseLine { get; } = baseLine;

    public bool IsSmallerThanBaseline(int number)
    {
        return number < BaseLine;
    }

    public static string DoMagic(int i) => i < 18 ? "child" : "adult";
}