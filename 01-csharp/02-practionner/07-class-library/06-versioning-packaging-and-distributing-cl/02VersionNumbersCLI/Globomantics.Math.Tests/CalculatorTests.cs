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

        [Test]
        public void AsHexString()
        {
            string hex = Calculator.AsHex(255);

#if NET6_0
            Assert.That(hex, Is.EqualTo("FF from .NET 6"));
#elif NET461
            Assert.That(hex, Is.EqualTo("FF from .NET Framework 4.6.1"));
#elif NETCOREAPP3_1
            Assert.That(hex, Is.EqualTo("FF from .NET Standard 2.0"));
#else
#error No platform-specific test has been created
#endif      
        }

        [Test]
        public void Internal()
        {
            Calculator.SomeMethod();
        }
    }
}