using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using BankApp.Services;

namespace BankApp.Console
{
    public class Interface
    {
        public void Run()
        {
            var interfaceLogic = new InterfaceLogic();
            bool isEsc;
            var key = new ConsoleKeyInfo();
            do
            {
                interfaceLogic.LoginOrRegisterChoise(StartPage());
                WriteLine("Enter 'esc' to exit or any other key to continue.");
                key = ReadKey();
                isEsc = Checks.IsKey(key, ConsoleKey.Escape);
            }
            while (isEsc == false);
        }

        public char StartPage()
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

        public string LoginInput()
        {
            bool isMatch;
            string login;
            do
            {
                WriteLine("Enter login:");
                login = ReadLine();
                isMatch = string.IsNullOrEmpty(login);
            }
            while (isMatch == false);

            return login;
        }

        public string PasswordInput()
        {
            bool isMatch;
            string password;
            do
            {
                WriteLine("Enter password:");
                password = ReadLine();
                isMatch = string.IsNullOrEmpty(password);
            }
            while (isMatch == false);

            return password;
        }
    }
}
