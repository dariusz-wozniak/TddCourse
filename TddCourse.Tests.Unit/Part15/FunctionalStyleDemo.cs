using System.Collections.Generic;
using Moq;

namespace TddCourse.Tests.Unit.Part15
{
    class FunctionalStyleDemo
    {
        /// <summary>
        /// Doesn't add any value. For blog purposes only.
        /// </summary>
        private void Demo()
        {
            // ReSharper disable once UnusedVariable
            ICustomer customerMock = Mock.Of<ICustomer>(customer =>
                customer.FirstName == "John" &&
                customer.LastName == "Kowalski" &&
                customer.PercentageDiscount == 20 &&
                customer.PhoneNumber == Mock.Of<IPhoneNumber>(number => number.MobileNumber == "123-456-789") &&
                customer.Orders == new List<IOrder>
                {
                    Mock.Of<IOrder>(order => order.Id == 23 && order.Price == 20.01m),
                    Mock.Of<IOrder>(order => order.Id == 65 && order.Price == 59.99m),
                    Mock.Of<IOrder>(order => order.Id == 82 && order.Price == 9.99m),
                } &&
                customer.GetAge() == 20);
        }
    }
}
