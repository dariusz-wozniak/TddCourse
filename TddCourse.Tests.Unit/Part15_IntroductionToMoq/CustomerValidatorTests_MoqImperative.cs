using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TddCourse.CustomerExample;

namespace TddCourse.Tests.Unit.Part15_IntroductionToMoq
{
    public class CustomerValidatorTests_MoqImperative
    {
        [Test]
        public void WhenCustomerIsNull_ThenArgumentNullExceptionIsThrown()
        {
            var validator = new CustomerValidator();

            Action action = () => validator.Validate(null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void WhenCustomerHasAgeLessThan18_ThenValidationFails()
        {
            var validator = new CustomerValidator();

            var customerMock = new Mock<ICustomer>();
            customerMock.Setup(x => x.GetAge()).Returns(16);

            bool validate = validator.Validate(customerMock.Object);

            validate.Should().BeFalse();
        }

        [Test]
        public void WhenCustomerHasAgeGreaterThanOrEqualTo18_ThenValidationPasses([Values(18, 19)] int expectedAge)
        {
            var validator = new CustomerValidator();

            var customerMock = new Mock<ICustomer>();
            customerMock.Setup(x => x.GetAge()).Returns(expectedAge);

            bool validate = validator.Validate(customerMock.Object);

            validate.Should().BeTrue();
        }
    }
}
