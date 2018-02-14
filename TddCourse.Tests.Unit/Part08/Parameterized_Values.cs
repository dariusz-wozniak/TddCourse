using NUnit.Framework;
using TddCourse.CalculatorExample;

namespace TddCourse.Tests.Unit.Part08
{
    public class Parameterized_Values
    {
        [Test]
        public void Divide_DividendIsZero_ReturnsQuotientEqualToZero(
            [Values(-2, -1, 1, 2)] double divisor)
        {
            var calc = new Calculator();
            float quotient = calc.Divide(0, divisor);

            Assert.AreEqual(0, quotient);
        }
    }
}