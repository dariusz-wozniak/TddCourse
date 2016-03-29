using System;

namespace TddCourse.CustomerExample
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetDateTime() => DateTime.Now;
    }
}