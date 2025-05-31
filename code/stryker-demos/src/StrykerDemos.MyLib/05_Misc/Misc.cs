using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace StrykerDemos.MyLib._05_Misc;

[SuppressMessage("Style", "IDE0022:Use block body for method")]
public static class Misc
{
    public static bool DoRegexMagic(string input)
    {
        Regex regex = new(@"\w");
        return regex.IsMatch(input);
    }

    public static decimal DoMathMagic(decimal input) => 
        Math.Floor(input);
}