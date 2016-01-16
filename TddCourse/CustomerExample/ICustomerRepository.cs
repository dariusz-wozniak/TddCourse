using System.Collections.Generic;

namespace TddCourse.CustomerExample
{
    public interface ICustomerRepository
    {
        IReadOnlyList<ICustomer> AllCustomers { get; }
        bool Add(ICustomer customer);
    }
}