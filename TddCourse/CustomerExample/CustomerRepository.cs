using System.Collections.Generic;

namespace TddCourse.CustomerExample
{
    public class CustomerRepository
    {
        private readonly List<ICustomer> _allCustomers;
        private readonly ICustomerValidator _customerValidator;

        public IReadOnlyList<ICustomer> AllCustomers => _allCustomers.AsReadOnly();

        public CustomerRepository(ICustomerValidator customerValidator)
        {
            _allCustomers = new List<ICustomer>();

            _customerValidator = customerValidator;
        }

        public bool Add(ICustomer customer)
        {
            if (_customerValidator.Validate(customer))
            {
                _allCustomers.Add(customer);
                return true;
            }

            return false;
        }
    }
}
