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
    public void CaculateMonthlyPayment_ShouldWork(int borrowedAmount, int duration, decimal rate, int expectedResult)
    {
        var actualResult = HomeLoan.CaculateMonthlyPayment(borrowedAmount, duration, rate);

        Assert.Equal(expectedResult, actualResult);
    }
}