using System;
using BankApp.Infrastructure;
using static System.Console;

namespace BankApp.Services
{
    public class Checks
    {
        public static bool IsKey(ConsoleKeyInfo key, ConsoleKey consoleKey)
        {
            return key.Key == consoleKey ? true : false;
        }

        public static bool IsKey(ConsoleKeyInfo key, ConsoleKey consoleKey1, ConsoleKey consoleKey2)
        {
            return key.Key == consoleKey1 || key.Key == consoleKey2 ? true : false;
        }

        public static bool IsUniqueLogin(string login)
        {
            using (var context = new BankDbConnection())
            {
                var logins = context.LoginsAndPasswords.Where(l => l.Login == login).ToList();
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
