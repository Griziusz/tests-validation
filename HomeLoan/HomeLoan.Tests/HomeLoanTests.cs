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

    [InlineData(0, 1, 0, 0)]

    [InlineData(1000, 1, 0, 1000)]
    [InlineData(10000, 1, 0, 10000)]

    [InlineData(1000, 10, 0, 100)]
    [InlineData(10000, 10, 0, 1000)]
    [InlineData(10000, 100, 0, 100)]

    [InlineData(1000, 1, 12, 1010)]
    [InlineData(1000, 1, 0.12, 1000.1)]
    [InlineData(0.1, 1, 1200, 0.2)]
    public void CaculateMonthlyPayment_ShouldWork(decimal borrowedAmount, int duration, decimal rate, decimal expectedResult)
    {
        var actualResult = HomeLoan.CaculateMonthlyPayment(borrowedAmount, duration, rate);

        Assert.Equal(expectedResult, actualResult);
    }
}