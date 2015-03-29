using NUnit.Framework;

namespace TddCourse.Tests.Unit.Part10
{
    public class Theory
    {
        [Datapoint]
        public int Zero = 0;

        [Datapoint]
        public int Negative = -1;
        
        [Datapoint]
        public int Positive = 1;

        /// <summary>
        /// positive / negative = negative
        /// </summary>
        [Theory]
        public void WhenDividendIsPositiveAndDivisorIsNegative_TheQuotientIsNegative(int dividend, int divisor)
        {
            Assume.That(dividend > 0);
            Assume.That(divisor < 0);

            var calculator = new Calculator();

            float quotient = calculator.Divide(dividend, divisor);

            Assert.That(quotient < 0);
        }

        /// <summary>
        /// 0 / x = 0
        /// </summary>
        [Theory]
        public void WhenDividendIsEqualToZero_TheQuotientIsEqualToZero(int dividend, int divisor)
        {
            Assume.That(dividend == 0);
            Assume.That(divisor != 0);

            var calculator = new Calculator();

            float quotient = calculator.Divide(dividend, divisor);

            Assert.That(quotient == 0);
        }
    }
}
