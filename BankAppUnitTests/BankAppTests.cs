using BankApp.Core;
using BankApp.Services;
using BankApp.Shared;

namespace BankAppUnitTests
{
    public class BankAppTests
    {
        [Theory]
        [InlineData("login", "password", 1)]
        public void TestCheckLoginAndPassword(string login, string password, int expected)
        {
            int actual = LoginChecks.CheckLoginAndPassword(login, password);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, true)]
        public void TestIsValidPersonId(int personId, bool expected)
        {
            bool actual = LoginChecks.IsValidPersonId(personId);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("login", false)]
        public void TestIsUniqueLogin(string login, bool expected)
        {
            bool actual = LoginChecks.IsUniqueLogin(login);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("", true)]
        public void TestIsEmptyLogin(string login, bool expectedd)
        {
            bool actual = LoginChecks.IsEmptyLogin(login);

            Assert.Equal(expectedd, actual);
        }

        [Theory]
        [InlineData("0", 0, true)]
        public void TestIsAccountChoiseNumber(string number, int count, bool expected)
        {
            bool actual = Checks.IsAccountChoiseNumber(number, count);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("3", 3, true)]
        public void TestIsRightNumber(string number, int count, bool expected)
        {
            bool actual = Checks.IsAccountChoiseNumber(number, count);

            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("name", true)]
        public void TestUniqueName(string accountName, bool expected)
        {
            bool actual = Checks.IsUniqueAccountName(accountName);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, "Yury")]
        public void TestGetPersonName(int personId, string expected)
        {
            Person person = PersonServices.GetPersonData(personId);

            string actual = person.Name;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, "Shemetov")]
        public void TestGetPersonSurname(int personId, string expected)
        {
            Person person = PersonServices.GetPersonData(personId);

            string actual = person.Surname;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(15, 1, 100, true)]
        public void TestIsAllowedOverdraft(int accountId, int accountTypeId, decimal sum, bool expected)
        {
            bool actual = Checks.IsAllowedOverdraft(accountId, accountTypeId, sum);

            Assert.Equal(expected, actual);
        }
    }
}