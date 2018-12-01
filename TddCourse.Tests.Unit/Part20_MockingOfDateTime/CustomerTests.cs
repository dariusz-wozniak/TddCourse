using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TddCourse.CustomerExample;

namespace TddCourse.Tests.Unit.Part20_MockingOfDateTime
{
    public class AgeCalculatorTests
    {
        [Test]
        public void Test()
        {
            var currentDate = new DateTime(2015, 1, 1);
            var dateTimeProvider = Mock.Of<IDateTimeProvider>(provider => provider.GetDateTime() == currentDate);

            var ageCalculator = new AgeCalculator(dateTimeProvider);

            var dateOfBirth = new DateTime(1990, 1, 1);
            int age = ageCalculator.GetAge(dateOfBirth);

            age.Should().Be(25);
        }
    }
}
