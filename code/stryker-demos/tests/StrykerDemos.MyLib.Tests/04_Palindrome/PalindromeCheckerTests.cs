using System.Diagnostics.CodeAnalysis;

using StrykerDemos.MyLib._04_Palindrome;

namespace StrykerDemos.MyLib.Tests._04_Palindrome;

[SuppressMessage("Style", "IDE0022:Use block body for method")]
public class PalindromeCheckerTests
{
    [Fact]
    public void IsPalindrome_works() 
        => PalindromeChecker.IsPalindrome("noon").Should().BeTrue();
}