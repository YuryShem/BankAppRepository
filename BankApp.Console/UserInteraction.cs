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

        public void UserPage(int personId)
        {
            Account account;
            account = AccountServices.InitializeAccount(AccountServices.SelectUserAccount(personId));
            WriteLine($"Yor balance is {account.Balance}");
            WriteLine("Chose some action or click 'esc' to exit");

        }
    }
}
