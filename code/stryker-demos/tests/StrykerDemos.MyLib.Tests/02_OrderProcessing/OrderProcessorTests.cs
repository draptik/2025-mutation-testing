using System.Diagnostics.CodeAnalysis;

using StrykerDemos.MyLib._02_OrderProcessing;

namespace StrykerDemos.MyLib.Tests._02_OrderProcessing;

[SuppressMessage("Style", "IDE0022:Use block body for method")]
public class OrderProcessorTests
{
    private readonly OrderProcessor _sut = new();

    [Fact]
    public void Given_order_amount_below_100_returns_no_discount_applied() 
        => _sut.ApplyDiscount(99).Should().Be(99);

    [Fact]
    public void Given_order_amount_between_100_and_500_returns_5_percent_discount_applied() 
        => _sut.ApplyDiscount(200).Should().Be(190); // 200 * 0.95

    [Fact]
    public void Given_order_amount_above_500_returns_10_percent_discount_applied() 
        => _sut.ApplyDiscount(600).Should().Be(540); // 600 * 0.90
}