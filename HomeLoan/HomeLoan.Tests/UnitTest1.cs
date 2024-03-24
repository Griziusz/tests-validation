using HomeLoan;

namespace HomeLoan.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var result = HomeLoan.HelloWord();

        Assert.Equal("Hello, World!", result);
    }
}