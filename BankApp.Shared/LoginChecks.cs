using System;
using System.Net.WebSockets;
using BankApp.Infrastructure;
using static System.Console;

namespace BankApp.Shared
{
    public class LoginChecks
    {
        public static int CheckLoginAndPassword(string login, string password)
        {
            using (var context = new BankDbConnection())
            {
                try
                {
                    var user = context.Login.Where(l => l.Login == login && l.Password == password).First();

                    return user.PersonId;
                }
                catch 
                {
                    return 0;
                }
            }
        }

        public static bool IsValidPersonId(int personId)
        {
            return personId > 0 ? true : false;
        }

        public static bool IsUniqueLogin(string login)
        {
            using (var context = new BankDbConnection())
            {
                var logins = context.Login.Where(l => l.Login == login).ToList();
                if (logins.Count > 0)
                {
                    WriteLine("This login already exists. Please Try again or enter 'r' to register.");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static bool IsEmptyLogin(string login)
        {
            if (string.IsNullOrEmpty(login))
            {
                WriteLine("You entered an empty value. Please try again.");
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
