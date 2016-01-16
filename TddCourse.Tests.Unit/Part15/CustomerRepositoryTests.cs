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
        public void WhenTryingToAddCustomerThatIsNotValidated_ThenCustomerIsNotAdded()
        {
            var customerValidatorMock = Mock.Of<ICustomerValidator>(validator => validator.Validate(It.IsAny<ICustomer>()) == false);

            var customerRepository = new CustomerRepository(customerValidatorMock);

            customerRepository.Add(It.IsAny<ICustomer>());

            customerRepository.AllCustomers.Should().BeEmpty();
        }

        [Test]
        public void WhenTryingToAddMultipleCustomers_ThenOnlyValidatedOnesAreAdded()
        { 
            var customerValidatorMock = Mock.Of<ICustomerValidator>(validator => validator.Validate(It.Is<ICustomer>(customer => customer.FirstName == "John")) == true);

            var customerRepository = new CustomerRepository(customerValidatorMock);

            customerRepository.Add(Mock.Of<ICustomer>(customer => customer.FirstName == "John"));
            customerRepository.Add(Mock.Of<ICustomer>(customer => customer.FirstName == "NotJohn"));

            customerRepository.AllCustomers.Should().HaveCount(1).And.OnlyContain(customer => customer.FirstName == "John");
        }

        [Test]
        public void WhenAddingCustomer_ThenValidateMethodOfValidatorIsCalledOnce()
        {
            var customerValidatorMock = Mock.Of<ICustomerValidator>(validator => validator.Validate(It.Is<ICustomer>(customer => customer.FirstName == "John")));

            var customerRepository = new CustomerRepository(customerValidatorMock);

            customerRepository.Add(Mock.Of<ICustomer>(customer => customer.FirstName == "John"));

            Mock.Get(customerValidatorMock).Verify(validator => validator.Validate(It.Is<ICustomer>(customer => customer.FirstName == "John")), Times.Once);
        }
    }
}
