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
            int personId;
            bool isEsc;
            do
            {
                personId = UserInteractionLogic.DoLoginOrRegisterChoise(DoStartPage());
                UserPage(personId);
                isEsc = KeyboardInput.EnterExitKey();
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
            bool isEscape;
            Account account;
            account = AccountServices.InitializeAccount(AccountServices.SelectUserAccount(personId));
            do
            {
                WriteLine($"Yor balance is {account.Balance}");
                WriteLine("Choose some action to continue.");
                AccountServices.ChooseAccountForAction(account);
                isEscape = KeyboardInput.EnterExitKey();
            }
            while (!isEscape);
        }
    }
}
