
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

    public static int CaculateMonthlyPayment(int borrowedAmount, int duration, decimal rate)
    {
        return (int)((decimal)borrowedAmount * (1m +((rate / 100m) / 12m)) / (decimal)duration);
    }
}
