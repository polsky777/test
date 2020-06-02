using Moq;
using NUnit.Framework;
using System;
using static ConsoleApp4.Program;

namespace ConsoleApp4
{
    [TestFixture]
    public class Testy
    {
        [Test]
        public void AttackArmourBreakTest()
        {
            // Arrange:
            var currentDate = new DateTime(2015, 1, 1);
            var dateOfBirth = new DateTime(1990, 1, 1);
            var dateTimeProvider = Mock.Of<IDateTimeProvider>(provider =>
              provider.GetDateTime() == currentDate);
            var ageCalculator = new AgeCalculator(dateTimeProvider);

            // Act:
            int age = ageCalculator.GetAge(dateOfBirth);

            // Assert:
            Assert.AreEqual(25, age);

        }
    }
}