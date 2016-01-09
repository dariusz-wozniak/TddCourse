using System;

namespace TddCourse.CustomerExample
{
    public class CustomerValidator
    {
        private const int MinimumAge = 18;

        public bool Validate(ICustomer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));

            if (customer.GetAge() < MinimumAge) return false;
            return true;
        }
    }
}