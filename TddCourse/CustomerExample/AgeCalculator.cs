using System;

namespace TddCourse.CustomerExample
{
    public class AgeCalculator
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public AgeCalculator(IDateTimeProvider dateTimeProvider)
        {
            if (dateTimeProvider == null) throw new ArgumentNullException(nameof(dateTimeProvider));
            _dateTimeProvider = dateTimeProvider;
        }

        /// <summary>
        /// From http://stackoverflow.com/a/229/297823
        /// </summary>
        public int GetAge(DateTime dateOfBirth)
        {
            // Code from http://stackoverflow.com/a/229/297823
            DateTime now = _dateTimeProvider.GetDateTime();
            int age = now.Year - dateOfBirth.Year;

            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day))
            {
                age--;
            }

            return age;
        }
    }
}