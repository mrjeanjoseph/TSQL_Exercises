using Xunit;

namespace ConsoleCalculator.Tests.xUnit;

public class UnitTest1
{
    [Fact]
    public void ThrowWhenUnsupportedOperation()
    {
        var sut = new Calculator();

        //Assert.Throws<CalculationOperationNotSupportedException>(
        //              () => sut.Calculate(1, 1, "+"));

        //Assert.Throws<CalculationException>(() => sut.Calculate(1, 1, "+"));

        //Assert.ThrowsAny<CalculationException>(() => sut.Calculate(1, 1, "+"));

        var ex = Assert.Throws<CalculationOperationNotSupportedException>(
                () => sut.Calculate(1, 1, "+"));

        Assert.Equal("+", ex.Operation);
    }
}
