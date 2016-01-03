namespace TddCourse.Tests.Unit.Part14
{
    internal class CustomerMock : ICustomer
    {
        private readonly int _expectedAge;

        public CustomerMock(int expectedAge)
        {
            _expectedAge = expectedAge;
        }

        public int GetAge() => _expectedAge;
    }
}