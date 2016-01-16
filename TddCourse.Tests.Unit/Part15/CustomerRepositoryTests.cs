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
            var customerValidatorMock = new Mock<ICustomerValidator>();

            var customerRepository = new CustomerRepository(customerValidatorMock.Object);

            customerRepository.Add(Mock.Of<ICustomer>(customer => customer.FirstName == "John"));

            customerValidatorMock.Verify(x => x.Validate(It.IsAny<ICustomer>()), Times.Exactly(2));
        }

        [Test]
        public void WhenAddingCustomer_ThenValidateMethodOfValidatorIsCalledOnce__Functional()
        {
            var customerValidatorMock = Mock.Of<ICustomerValidator>();

            var customerRepository = new CustomerRepository(customerValidatorMock);

            customerRepository.Add(Mock.Of<ICustomer>(customer => customer.FirstName == "John"));

            Mock.Get(customerValidatorMock).Verify(validator => validator.Validate(It.Is<ICustomer>(customer => customer.FirstName == "John")), Times.Once);
        }
    }
}
