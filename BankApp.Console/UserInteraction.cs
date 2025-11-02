using BankApp.Core;
using BankApp.Services;
using BankApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace BankApp.Console
{
    public class UserInteraction
    {
        public void Run()
        {
            bool isEsc;
            var key = new ConsoleKeyInfo();
            do
            {
                UserInteractionLogic.DoLoginOrRegisterChoise(DoStartPage());
                WriteLine("Enter 'esc' to exit or any other key to continue.");
                key = ReadKey();
                isEsc = Checks.IsKey(key, ConsoleKey.Escape);
            }
            while (isEsc == false);
        }

        public char DoStartPage()
        {
            bool isLOrR;
            var key = new ConsoleKeyInfo();
            do
            {
                WriteLine("Do you whant to log in or register? l/r");
                key = ReadKey();
                isLOrR = Checks.IsKey(key, ConsoleKey.L, ConsoleKey.R);
            }
            while (isLOrR == false);

            return key.KeyChar;
        }

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
