using System.Diagnostics.CodeAnalysis;

using StrykerDemos.MyLib._00_FizzBuzz;

namespace StrykerDemos.MyLib.Tests._00_FizzBuzz;

[SuppressMessage("Style", "IDE0022:Use block body for method")]
public class FizzBuzzerTests
{
    private static string FizzBuzz(int number) => 
        FizzBuzzer.FizzBuzz(number);
    
    private static IEnumerable<string> FizzBuzzNumbers(int maxNumber)
    {
        List<int> numbers = [..Enumerable.Range(1, maxNumber)];
        return numbers.Select(FizzBuzz);
    }

    
    [Fact]
    public void When_given_3_return_Fizz() => 
        FizzBuzz(3).Should().Be("Fizz");
    
    [Fact]
    public void When_given_5_return_Buzz() => 
        FizzBuzz(5).Should().Be("Buzz");
    
    [Fact]
    public void When_given_15_return_FizzBuzz() => 
        FizzBuzz(15).Should().Be("FizzBuzz");
    
    [Fact]
    public void When_given_1_return_1() => 
        FizzBuzz(1).Should().Be("1");

    [Fact]
    public void When_given_numbers_1_to_15_return_correct_list() =>
        FizzBuzzNumbers(15)
            .Should()
            .BeEquivalentTo(new List<string>
            {
                "1", 
                "2", 
                "Fizz", 
                "4", 
                "Buzz", 
                "Fizz", 
                "7", 
                "8", 
                "Fizz", 
                "Buzz", 
                "11", 
                "Fizz", 
                "13", 
                "14", 
                "FizzBuzz"
            });
}