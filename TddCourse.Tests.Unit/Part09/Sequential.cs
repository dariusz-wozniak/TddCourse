using NUnit.Framework;
using TddCourse.CalculatorExample;

namespace TddCourse.Tests.Unit.Part09
{
    public class Sequential
    {
        [Test]
        [Sequential]
        public void Divide_DivisorIsNegativeOfDividend_ReturnsMinusOne(
            [Values(1, 2, 30)] int dividend,
            [Values(-1, -2, -30)] int divisor)
        {
            var calc = new Calculator();
            float quotient = calc.Divide(dividend, divisor);

            Assert.That(quotient == -1);
        }
    }
}