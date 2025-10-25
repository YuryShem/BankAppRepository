using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using BankApp.Infrastructure;
using BankApp.Core;
using Microsoft.EntityFrameworkCore.Query.Internal;
//using BankApp.Console;

namespace BankApp.Services
{
    public class LoginServices
    {
        public static void LogIn(string login, string password)
        {
            bool isMatch;
            int personId;
            do
            {
                personId = LoginChecks.CheckLoginAndPassword(login, password);
                isMatch = LoginChecks.IsValidPersonId(personId);
            }
            while (!isMatch);

            AccountServices.AccontOutput(AccountServices.InitializeAccount(AccountServices.SelectUserAccount(personId)));
        }

        public static void DoRegister(string name, string surname, string login, string password)
        {
            using (var context = new BankDbConnection())
            {
                var person = new PersonsTable
                {
                    Name = name,
                    Surname = surname
                };
                context.Persons.Add(person);
                context.SaveChanges();

                var logAndPassw = new LoginTable
                {
                    Login = login,
                    Password = password,
                    PersonId = person.PersonId
                };
                context.Logins.Add(logAndPassw);
                context.SaveChanges();

                AccountServices.AccontOutput(AccountServices.InitializeAccount(AccountServices.SelectUserAccount(logAndPassw.PersonId)));
            }
        }

        public static void Test()
        {
            using (var context = new BankDbConnection())
            {
                var data = context.AccountBalance.Find(3);
                WriteLine($"{data.Balance}");

                var data1 = context.LoginsTable.Find(1);
                WriteLine($"{data1.PersonId}, {data1.Login}, {data1.Password}");

                //var data = context.AccountTypes.Find(1);
                //WriteLine($"{data.AccountType}");
            }
        }
    }
}
