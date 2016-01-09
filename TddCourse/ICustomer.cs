using System.Collections.Generic;

namespace TddCourse
{
    public interface ICustomer
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int PercentageDiscount { get; set; }

        IPhoneNumber PhoneNumber { get; set; }

        IList<IOrder> Orders { get; set; }

        int GetAge();
    }
}