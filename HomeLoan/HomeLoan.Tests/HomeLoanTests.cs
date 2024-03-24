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
    public void CaculateMonthlyPayment_ShouldWork(int borrowedAmount, int duration, decimal rate, int expectedResult)
    {
        var actualResult = HomeLoan.CaculateMonthlyPayment(borrowedAmount, duration, rate);

        Assert.Equal(expectedResult, actualResult);
    }
}