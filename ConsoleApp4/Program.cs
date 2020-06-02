using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    { 
            static void Main(string[] args)
            {
                DateTimeProvider dateTimeProvider = new DateTimeProvider();
                AgeCalculator ageCalculator = new AgeCalculator(dateTimeProvider);
                DateTime BirthDay = new DateTime(2005, 05, 10);
                int Age = ageCalculator.GetAge(BirthDay);
                Console.WriteLine(Age);
                Console.ReadKey();
            }

            public class AgeCalculator
        {
            private readonly IDateTimeProvider _dateTimeProvider;

            public AgeCalculator(IDateTimeProvider dateTimeProvider)
            {
                if (dateTimeProvider == null) throw new ArgumentNullException(nameof(dateTimeProvider));
                _dateTimeProvider = dateTimeProvider;
            }

            public int GetAge(DateTime dateOfBirth)
            {
                DateTime now = DateTime.Now;
                int age = now.Year - dateOfBirth.Year;

                if (now.Month < dateOfBirth.Month ||
                   (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day))
                {
                    age--;
                }

                return age;
            }
        }

        public interface IDateTimeProvider
        {
            DateTime GetDateTime();
        }
        public class DateTimeProvider : IDateTimeProvider
        {
            public DateTime GetDateTime() => DateTime.Now;
        }

    }
}
    