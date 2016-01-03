using System;
using FluentAssertions;
using NUnit.Framework;

namespace TddCourse.Tests.Unit.Part14   
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
            var customer = new CustomerMock(expectedAge: 16);

            bool validate = validator.Validate(customer);

            validate.Should().BeFalse();
        }

        [Test]
        public void WhenCustomerHasAgeGreaterThanOrEqualTo18_ThenValidationPasses([Values(18, 19)] int expectedAge)
        {
            var validator = new CustomerValidator();
            var customer = new CustomerMock(expectedAge: 18);

            bool validate = validator.Validate(customer);

            validate.Should().BeTrue();
        }
    }

    internal class CustomerMock : ICustomer
    {
        private readonly int _expectedAge;

        public CustomerMock(int expectedAge)
        {
            _expectedAge = expectedAge;
        }

        public int GetAge() => _expectedAge;
    }
}
