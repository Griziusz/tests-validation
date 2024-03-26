
using System;

namespace HomeLoan;

public static class HomeLoan
{
    public static string HelloWord()
    {
        return "Hello, World!";
    }

    public static void Main()
    {
        Console.WriteLine(CalculateMonthlyPayment(1000, 1, 12));
    }

    public static double CalculateMonthlyPayment(double borrowedAmount, double duration, double rateInPercent)
    {
        if (!(rateInPercent > 0))
            throw new ArgumentException("rate should be greater than 0", "rateInPercent");

        var rate = rateInPercent / 100;
        var monthlyRate = rate / 12;
        var monthlyPayment = (borrowedAmount * monthlyRate) / (1 - Math.Pow(1 + monthlyRate, -duration));
        return monthlyPayment;
    }
}
