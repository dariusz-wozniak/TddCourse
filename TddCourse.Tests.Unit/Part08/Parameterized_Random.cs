using NUnit.Framework;
using TddCourse.CalculatorExample;

namespace TddCourse.Tests.Unit.Part08
{
    [TestFixture]
    public class Parameterized_Random
    {
        [Test]
        public void Divide_DividendAndDivisorAreRandomPositiveNumbers_ReturnsPositiveQuotient(
            [Random(min: 1, max: 100, count: 10)] double dividend,
            [Random(min: 1, max: 100, count: 10)] double divisor)
        {
            var calc = new Calculator();
            float quotient = calc.Divide(dividend, divisor);
            Assert.That(quotient > 0);
        }
    }
}