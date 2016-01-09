using System.Collections.Generic;
using TddCourse.CustomerExample;

namespace TddCourse.Tests.Unit.Part14
{
    internal class CustomerMock : ICustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PercentageDiscount { get; set; }
        public IPhoneNumber PhoneNumber { get; set; }
        public IList<IOrder> Orders { get; set; }

        private readonly int _expectedAge;

        public CustomerMock(int expectedAge)
        {
            _expectedAge = expectedAge;
        }

        public int GetAge() => _expectedAge;
    }
}