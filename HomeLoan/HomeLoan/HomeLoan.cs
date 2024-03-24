
namespace HomeLoan;

public static class HomeLoan
{
    public static string HelloWord()
    {
        return "Hello, World!";
    }

    public static void Main()
    {
        Console.WriteLine(HelloWord());
    }

    public static int CaculateMonthlyPayment(int borrowedAmount, int duration, decimal rateInPercent)
    {
        var rate = rateInPercent / 100m;
        var monthlyRate = rate / 12m;
        var totalAmountToRepay = borrowedAmount * (1 + monthlyRate);
        return (int)(totalAmountToRepay / (decimal)duration);
    }
}
