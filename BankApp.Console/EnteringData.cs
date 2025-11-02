using BankApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace BankApp.Console
{
    public class EnteringData
    {
        public static string EnterLogin()
        {
            bool isMatch;
            string login;
            do
            {
                WriteLine("Enter login:");
                login = ReadLine();
                isMatch = string.IsNullOrEmpty(login);
            }
            while (isMatch);

            return login;
        }

        public static string EnterUniqueLogin() // check true
        {
            bool isMatch;
            string login;
            do
            {
                WriteLine("Enter login:");
                login = ReadLine();
                isMatch = string.IsNullOrEmpty(login) && LoginChecks.IsUniqueLogin(login);
            }
            while (isMatch == false);

            return login;
        }

        public static string EnterPassword()
        {
            bool isMatch;
            string password;
            do
            {
                WriteLine("Enter password:");
                password = ReadLine();
                isMatch = string.IsNullOrEmpty(password);
            }
            while (isMatch);

            return password;
        }

        public static string EnterName()
        {
            bool isMatch;
            string name;
            do
            {
                WriteLine("Enter your name: ");
                name = ReadLine();
                isMatch = string.IsNullOrEmpty(name) && name.All(char.IsLetter);
            }
            while (isMatch == false);

            return name;
        }

        public static string EnterSurname()
        {
            bool isMatch;
            string surname;
            do
            {
                WriteLine("Enter your surname");
                surname = ReadLine();
                isMatch = string.IsNullOrEmpty(surname) && surname.All(char.IsLetter);
            }
            while (isMatch == false);

            return surname;
        }
    }
}
