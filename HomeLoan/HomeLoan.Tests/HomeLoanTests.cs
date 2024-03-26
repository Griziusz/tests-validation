using System;
using System.Reflection;
using HomeLoan;

namespace HomeLoan.Tests;

public class HomeLoanTests
{
    [Fact]
    public void Test1()
    {
        var result = HomeLoan.HelloWord();

        Assert.Equal("Hello, World!", result);
    }

    [Theory]

    [InlineData(0, 1, 1, 0, 0)]

    [InlineData(1000, 1, 12, 1010, 1e-12)]
    [InlineData(1000, 1, 0.12, 1000.1, 1e-9)]
    [InlineData(0.1, 1, 1200, 0.2, 1e-12)]

    [InlineData(1000, 12, 10, 87.92, 1e-2)]
    [InlineData(2_500_000, 25 * 12, 7, 17_669, 1)]
    public void CaculateMonthlyPayment_ShouldWork(double borrowedAmount, int duration, double rate, double expectedResult, double epsilon)
    {
        var actualResult = HomeLoan.CalculateMonthlyPayment(borrowedAmount, duration, rate);

        Assert.Equal(expectedResult, actualResult, epsilon);
    }

    [Theory]

    [InlineData(0, 1, 0, "rate should be greater than 0 (Parameter 'rateInPercent')")]
    [InlineData(1000, 1, 0, "rate should be greater than 0 (Parameter 'rateInPercent')")]
    [InlineData(-1000, 1, 12, "borrowedAmount should be positive (Parameter 'borrowedAmount')")]
    [InlineData(1000, 0, 12, "duration should be greater than 0 (Parameter 'duration')")]
    public void CalculateMonthlyPayment_ShouldThrowArgumentException(double borrowedAmount, double duration, double rate, string expectedExceptionMessage)
    {
        Exception? caughtException = null;

        try
        {
            HomeLoan.CalculateMonthlyPayment(borrowedAmount, duration, rate);
        }
        catch(Exception e)
        {
            caughtException = e;
        }

        Assert.NotNull(caughtException);
        Assert.IsType<ArgumentException>(caughtException);
        Assert.Equal(expectedExceptionMessage, caughtException.Message);
    }
}