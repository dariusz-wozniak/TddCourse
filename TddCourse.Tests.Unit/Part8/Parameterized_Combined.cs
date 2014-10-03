using NUnit.Framework;

namespace TddCourse.Tests.Unit.Part8
{
    // Remember to never use Random attribute in unit tests
    [TestFixture]
    public class Parameterized_Combined
    {
        [Test]
        public void Divide_DividendIsPositiveValue(
            [Random(min: 1, max: 100, count: 10)] double dividend,
            [Range(from: 10, to: 100, step: 10)] double divisor)
        {
            var calc = new Calculator();
            float quotient = calc.Divide(dividend, divisor);
            Assert.That(quotient > 0);
        }
    }
}