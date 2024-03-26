using System;
using System.Reflection;
using HomeLoan;

namespace HomeLoan.Tests;

public class HomeLoanTests
{
    private const double EPSILON = 1e-2;

    [Fact]
    public void Test1()
    {
        var result = HomeLoan.HelloWord();

        Assert.Equal("Hello, World!", result);
    }

    [Theory]

    [InlineData(0, 1, 1, 0)]

    [InlineData(1000, 1, 12, 1010)]
    [InlineData(1000, 1, 0.12, 1000.1)]
    [InlineData(0.1, 1, 1200, 0.2)]

    [InlineData(1000, 12, 10, 87.92)]
    public void CaculateMonthlyPayment_ShouldWork(double borrowedAmount, int duration, double rate, double expectedResult)
    {
        var actualResult = HomeLoan.CalculateMonthlyPayment(borrowedAmount, duration, rate);

        Assert.Equal(expectedResult, actualResult, EPSILON);
    }

    [Theory]

    [InlineData(0, 1, 0, "rate should be greater than 0 (Parameter 'rateInPercent')")]
    [InlineData(1000, 1, 0, "rate should be greater than 0 (Parameter 'rateInPercent')")]
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