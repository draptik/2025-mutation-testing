namespace StrykerDemos.MyLib._04_Palindrome;

public static class PalindromeChecker
{
    public static bool IsPalindrome(string s)
    {
        if (s.Length is 0 or 1)
        {
            return true;
        }
        
        char firstChar = s[0];
        char lastChar = s[^1];
        string mid = s[1..^1];
        return (firstChar == lastChar) && IsPalindrome(mid);
    }
}