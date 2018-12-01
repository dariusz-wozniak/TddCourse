using NUnit.Framework;
using TddCourse.CalculatorExample;

namespace TddCourse.Tests.Unit.Part11_GenericClasses
{
    [TestFixture(typeof(int))]
    [TestFixture(typeof(float))]
    [TestFixture(typeof(double))]
    [TestFixture(typeof(decimal))]
    public class GenericCalculatorTests<T>
    {
        [Test]
        public void AdditionTest()
        {
            var calculator = new GenericCalculator<T>();

            dynamic result = calculator.Add((dynamic) 2, (dynamic) 3);

            Assert.That(result, Is.EqualTo(5));
        }
    }
}