using NUnit.Framework;

namespace Globomantics.Math.Tests
{
    public class CalculatorTests
    {
        [Test]
        public void Add2PositiveNumbers()
        {
            var result = Calculator.Add(40, 2);

            Assert.That(result, Is.EqualTo(42));
        }
    }
}