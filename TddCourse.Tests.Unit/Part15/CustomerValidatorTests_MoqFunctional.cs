using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace TddCourse.Tests.Unit.Part15
{
    [TestFixture]
    public class CustomerValidatorTests_MoqFunctional
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

        // ReSharper disable once UnusedMember.Local
        private void FunctionalStyleDemo()
        {
            // ReSharper disable once UnusedVariable
            ICustomer customerMock = Mock.Of<ICustomer>(customer => 
                customer.FirstName == "John" &&
                customer.LastName == "Kowalski" &&
                customer.PercentageDiscount == 20 &&
                customer.PhoneNumber == Mock.Of<IPhoneNumber>(number => number.MobileNumber == "123-456-789") &&
                customer.Orders == new List<IOrder>
                {
                    Mock.Of<IOrder>(order => order.Id == 23),
                    Mock.Of<IOrder>(order => order.Id == 65),
                    Mock.Of<IOrder>(order => order.Id == 82),
                } &&
                customer.GetAge() == 20);
        }
    }
}