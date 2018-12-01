using NUnit.Framework;
using TddCourse.CalculatorExample;

namespace TddCourse.Tests.Unit.Part08_ParameterizedTests
{
    public class Parameterized_Combined
    {
        [Test]
        public void Divide_DividendIsPositiveValue(
            [Random(min: 1, max: 100, count: 10)] int dividend,
            [Range(@from: 10, to: 100, step: 10)] int divisor)
        {
            var calc = new Calculator();
            float quotient = calc.Divide(dividend, divisor);
            Assert.That(quotient > 0);
        }
    }
}