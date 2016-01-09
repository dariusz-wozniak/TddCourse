using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace TddCourse.Tests.Unit.Part15
{
    [TestFixture]
    public class CustomerValidatorTests
    {
        [Test]
        public void WhenCustomerIsNull_ThenArgumentNullExceptionIsThrown()
        {
            var validator = new CustomerValidator();

            Action action = () => validator.Validate(null);

            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void WhenCustomerHasAgeLessThan18_ThenValidationFails()
        {
            var validator = new CustomerValidator();

            Mock<ICustomer> customerMock = new Mock<ICustomer>();
            customerMock.Setup(x => x.GetAge()).Returns(16);

            bool validate = validator.Validate(customerMock.Object);

            validate.Should().BeFalse();
        }

        [Test]
        public void WhenCustomerHasAgeGreaterThanOrEqualTo18_ThenValidationPasses([Values(18, 19)] int expectedAge)
        {
            var validator = new CustomerValidator();

            Mock<ICustomer> customerMock = new Mock<ICustomer>();
            customerMock.Setup(x => x.GetAge()).Returns(expectedAge);

            bool validate = validator.Validate(customerMock.Object);

            validate.Should().BeTrue();
        }
    }
}
