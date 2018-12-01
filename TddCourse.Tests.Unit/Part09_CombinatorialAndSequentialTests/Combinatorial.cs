using NUnit.Framework;
using TddCourse.CalculatorExample;

namespace TddCourse.Tests.Unit.Part09_CombinatorialAndSequentialTests
{
    public class Combinatorial
    {
        [Test]
        [Combinatorial]
        public void Divide_DividendIsPositiveAndDivisorIsNegative_ReturnsNegativeQuotient(
            [Values(1, 2, 3, 4)] int dividend,
            [Values(-1, -2, -3)] int divisor)
        {
            var calc = new Calculator();
            float quotient = calc.Divide(dividend, divisor);

            Assert.That(quotient < 0);
        }
    }
}
