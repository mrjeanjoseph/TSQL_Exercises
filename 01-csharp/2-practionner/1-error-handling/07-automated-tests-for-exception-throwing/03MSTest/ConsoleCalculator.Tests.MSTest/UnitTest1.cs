using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleCalculator.Tests.MSTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void ThrowWhenUnsupportedOperation()
    {
        var sut = new Calculator();

        //Assert.ThrowsException<CalculationOperationNotSupportedException>(
        //                           () => sut.Calculate(1, 1, "+"));

        var ex = Assert.ThrowsException<CalculationOperationNotSupportedException>(
                                     () => sut.Calculate(1, 1, "+"));

        Assert.AreEqual("+", ex.Operation);
    }
}
