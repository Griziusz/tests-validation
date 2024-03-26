
using System;

namespace HomeLoan;

public static class HomeLoan
{
    public static string HelloWord()
    {
        return "Hello, World!";
    }

    public static void Main(string[] args)
    {
        if (args.Length != 3)
            throw new ArgumentException($"Parrameters: <borrowedAmount> <duration> <rateInPercent>");

        var borrowedAmount = Convert.ToDouble(args[0]);
        var duration = Convert.ToInt32(args[1]);
        var rateInPercent = Convert.ToDouble(args[2]);

        var monthlyPayment = CalculateMonthlyPayment(borrowedAmount, duration, rateInPercent);
        Console.WriteLine(monthlyPayment);
    }

    public static double CalculateMonthlyPayment(double borrowedAmount, double duration, double rateInPercent)
    {
        if (!(rateInPercent > 0))
            throw new ArgumentException("rate should be greater than 0", "rateInPercent");

        if (borrowedAmount < 0)
            throw new ArgumentException("borrowedAmount should be positive", "borrowedAmount");

        if (!(duration > 0))
            throw new ArgumentException("duration should be greater than 0", "duration");

        var rate = rateInPercent / 100;
        var monthlyRate = rate / 12;
        var monthlyPayment = (borrowedAmount * monthlyRate) / (1 - Math.Pow(1 + monthlyRate, -duration));

        if (monthlyPayment > double.MaxValue)
            throw new Exception("monthly payment is to high for the program to compute");

        return monthlyPayment;
    }
}
