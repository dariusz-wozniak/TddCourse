using NUnit.Framework;
using TddCourse.CalculatorExample;

namespace TddCourse.Tests.Unit.Part04_VeryFirstTest
{
    public class CalculatorTests
    {
        [Test]
        public void Add_AddsTwoPositiveNumbers_Calculated()
        {
            var calc = new Calculator();
            int sum = calc.Add(2, 2);
            Assert.AreEqual(4, sum);
        }
    }
}
