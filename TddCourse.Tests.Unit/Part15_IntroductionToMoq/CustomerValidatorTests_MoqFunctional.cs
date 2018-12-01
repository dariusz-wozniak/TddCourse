using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TddCourse.CustomerExample;

namespace TddCourse.Tests.Unit.Part15_IntroductionToMoq
{
    public class CustomerValidatorTests_MoqFunctional
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

            var customerMock = Mock.Of<ICustomer>(customer => customer.GetAge() == 16);

            bool validate = validator.Validate(customerMock);

            validate.Should().BeFalse();
        }

        [Test]
        public void WhenCustomerHasAgeGreaterThanOrEqualTo18_ThenValidationPasses([Values(18, 19)] int expectedAge)
        {
            var validator = new CustomerValidator();

            var customerMock = Mock.Of<ICustomer>(customer => customer.GetAge() == expectedAge);

            bool validate = validator.Validate(customerMock);

            validate.Should().BeTrue();
        }
    }
}