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
        public static int LogIn(string login, string password)
        {
            bool isMatch;
            int personId;
            do
            {
                personId = LoginChecks.CheckLoginAndPassword(login, password);
                isMatch = LoginChecks.IsValidPersonId(personId);
            }
            while (!isMatch);
            
            //AccountServices.AccontOutput(AccountServices.InitializeAccount(AccountServices.SelectUserAccount(personId)));
            return personId;
        }

        public static int DoRegister(string name, string surname, string login, string password)
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
                context.Login.Add(logAndPassw);
                context.SaveChanges();

                //AccountServices.AccontOutput(AccountServices.InitializeAccount(AccountServices.SelectUserAccount(logAndPassw.PersonId)));
                return logAndPassw.PersonId;
            }
        }
    }
}
