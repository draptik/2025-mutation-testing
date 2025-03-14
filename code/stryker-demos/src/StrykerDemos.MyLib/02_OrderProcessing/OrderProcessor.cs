namespace StrykerDemos.MyLib._02_OrderProcessing;

public class OrderProcessor
{
    public decimal ApplyDiscount(decimal orderAmount)
    {
        if (orderAmount >= 100 && orderAmount < 500)
        {
            return orderAmount * 0.95m; // 5% discount
        }

        if (orderAmount >= 500)
        {
            return orderAmount * 0.90m; // 10% discount
        }

        return orderAmount;
    }

    // public static decimal ApplyDiscount(decimal orderAmount) =>
    //     orderAmount switch
    //     {
    //         >= 100 and < 500 => orderAmount * 0.95m, // 5% discount
    //         >= 500 => orderAmount * 0.90m, // 10% discount
    //         _ => orderAmount
    //     };
}