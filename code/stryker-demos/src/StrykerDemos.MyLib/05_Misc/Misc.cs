using System.Text.RegularExpressions;

namespace StrykerDemos.MyLib._05_Misc;

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