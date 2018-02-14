using System;
using System.Threading.Tasks;
using NUnit.Framework;
using TddCourse.CalculatorExample;

namespace TddCourse.Tests.Unit.Part13
{
    public class AsyncTests
    {
        [Test]
        public async Task DivideAsyncTest()
        {
            var calculator = new Calculator();
            float quotient = await calculator.DivideAsync(10, 2);
            Assert.That(quotient, Is.EqualTo(5));
        }

        [Test]
        public void DivideAsyncLambdaTest()
        {
            var calculator = new Calculator();
            Assert.That(async () => await calculator.DivideAsync(10, 2), Is.EqualTo(5));
        }

        [Test]
        public void WhenDivisorIsZero_ThenDivideByZeroExceptionIsThrown()
        {
            var calculator = new Calculator();
            Assert.That(async () => await calculator.DivideAsync(2, 0), Throws.TypeOf<DivideByZeroException>());
        }
    }
}
