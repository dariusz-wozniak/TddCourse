using FluentAssertions;
using Moq;
using NUnit.Framework;
using TddCourse.CustomerExample;

namespace TddCourse.Tests.Unit.Part15
{
    [TestFixture]
    public class CustomerRepositoryTests
    {
        [Test]
        public void WhenTryingToAddCustomerThatIsNotValidated_ThenFalseIsReturned()
        {
            var customerValidatorMock = Mock.Of<ICustomerValidator>(validator => 
                validator.Validate(It.IsAny<ICustomer>()) == false);

            var customerRepository = new CustomerRepository(customerValidatorMock);

            bool added = customerRepository.Add(It.IsAny<ICustomer>());

            added.Should().BeFalse();
        }

        [Test]
        public void WhenTryingToAddCustomerThatIsNotValidated_ThenCustomerIsNotAdded()
        {
            var customerValidatorMock = Mock.Of<ICustomerValidator>(validator =>
                validator.Validate(It.IsAny<ICustomer>()) == false);

            var customerRepository = new CustomerRepository(customerValidatorMock);

            customerRepository.Add(It.IsAny<ICustomer>());

            customerRepository.AllCustomers.Should().BeEmpty();
        }

        [Test]
        public void WhenTryingToAddCustomerThatIsValidated_ThenTrueIsReturned()
        {
            var customerValidatorMock = Mock.Of<ICustomerValidator>(validator =>
                validator.Validate(It.IsAny<ICustomer>()) == true);

            var customerRepository = new CustomerRepository(customerValidatorMock);

            bool added = customerRepository.Add(It.IsAny<ICustomer>());

            added.Should().BeTrue();
        }

        [Test]
        public void WhenTryingToAddCustomerThatIsValidated_ThenCustomerIsAdded()
        {
            var customerMock = Mock.Of<ICustomer>(customer => customer.FirstName == "John");

            var customerValidatorMock = Mock.Of<ICustomerValidator>(validator =>
                validator.Validate(It.Is<ICustomer>(customer => customer.FirstName == "John")) == true);

            var customerRepository = new CustomerRepository(customerValidatorMock);

            customerRepository.Add(customerMock);

            customerRepository.AllCustomers.Should().HaveCount(1);
        }
    }
}
