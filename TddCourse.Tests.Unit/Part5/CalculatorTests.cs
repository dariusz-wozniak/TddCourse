using System;
using NUnit.Framework;
using TddCourse.CalculatorExample;

namespace TddCourse.Tests.Unit.Part5
{
    [TestFixture]
    public class CalculatorTests
    {
        [TestCase(4, 2, 2.0f)]
        [TestCase(-4, 2, -2.0f)]
        [TestCase(4, -2, -2.0f)]
        [TestCase(0, 3, 0.0f)]
        [TestCase(5, 2, 2.5f)]
        [TestCase(1, 3, 0.333333343f)]
        public void Divide_ReturnsProperValue(int dividend, int divisor, float expectedQuotient)
        {
            var calc = new Calculator();
            var quotient = calc.Divide(dividend, divisor);
            Assert.AreEqual(expectedQuotient, quotient);
        }

        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Divide_DivisionByZero_ThrowsException()
        {
            var calc = new Calculator();
            calc.Divide(2, 0);
        }

        [Test]
        public void Divide_DivisionByZero_ThrowsException_AssertThrows()
        {
            var calc = new Calculator();
            Assert.Throws<DivideByZeroException>(() => calc.Divide(2, 0));
        }

        [Test]
        public void Divide_OnCalculatedEventIsCalled()
        {
            var calc = new Calculator();

            bool wasEventCalled = false;
            calc.CalculatedEvent += (sender, args) => wasEventCalled = true;

            calc.Divide(1, 2);

            Assert.IsTrue(wasEventCalled);
        }
    }
}
