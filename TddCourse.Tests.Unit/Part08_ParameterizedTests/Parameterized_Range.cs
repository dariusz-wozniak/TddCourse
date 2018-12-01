using NUnit.Framework;
using TddCourse.CalculatorExample;

namespace TddCourse.Tests.Unit.Part08_ParameterizedTests
{
    public class Parameterized_Range
    {
        [Test]
        public void Divide_DividendIsZero_ReturnsQuotientEqualToZero(
            [Range(@from: 1, to: 5, step: 1)] double divisor)
        {
            var calc = new Calculator();
            float quotient = calc.Divide(0, divisor);

            Assert.AreEqual(0, quotient);
        } 
    }
}