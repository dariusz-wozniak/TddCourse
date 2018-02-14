using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TddCourse.CustomerExample;

namespace TddCourse.Tests.Unit.Part19
{
    public class TestDoubles
    {
        [Test]
        public void DummyExample()
        {
            string firstName = null;
            string lastName = It.IsAny<string>(); // Dummy

            Action act = () => new Customer(firstName, lastName);

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void StubExample()
        {
            var customerValidator = new CustomerValidator();
            var customer = Mock.Of<ICustomer>(c => c.GetAge() == 21); // Stub

            bool validate = customerValidator.Validate(customer);

            validate.Should().BeTrue();
        }

        [Test]
        public void MockExample()
        {
            var customerValidator = new CustomerValidator();
            var customer = Mock.Of<ICustomer>(c => c.GetAge() == 21); // Mock

            customerValidator.Validate(customer);

            Mock.Get(customer).Verify(x => x.GetAge()); // Verification of Mock
        }

        [Test]
        public void SpyExample()
        {
            var customerValidator = new CustomerValidator();
            var customer = Mock.Of<ICustomer>(c => c.GetAge() == 21); // Spy

            customerValidator.Validate(customer);

            Mock.Get(customer).Verify(x => x.GetAge(), Times.Once); // Verification of Spy
        }

        [Test]
        public void FakeExample()
        {
            var customerRepository = new FakeCustomerRepository(); // Fake
            customerRepository.Add(Mock.Of<ICustomer>(c => c.FirstName == "John" && c.LastName == "Kowalski"));
            customerRepository.Add(Mock.Of<ICustomer>(c => c.FirstName == "Steve" && c.LastName == "Jablonsky"));

            var customerReportingService = new CustomerReportingService(customerRepository);

            string report = customerReportingService.GenerateReport();

            report.Should().Be("John Kowalski\nSteve Jablonsky");
        }
    }

    internal class FakeCustomerRepository : ICustomerRepository
    {
        private readonly List<ICustomer> _customers = new List<ICustomer>();

        public IReadOnlyList<ICustomer> AllCustomers => _customers.AsReadOnly();

        public bool Add(ICustomer customer)
        {
            _customers.Add(customer);
            return true;
        }
    }
}
