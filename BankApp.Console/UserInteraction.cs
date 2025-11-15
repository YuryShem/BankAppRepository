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
        public static void Run()
        {
            int personId;
            bool isEsc;
            do
            {
                personId = UserInteractionLogic.DoLoginOrRegisterChoise(DoStartPage());
                DoUserChoisePage(personId);
                isEsc = KeyboardInput.EnterExitKey();
            }
            while (isEsc == false);
        }

        public static char DoStartPage()
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

        public static void DoUserAccountChoise(int personId)
        {
            int accountId = AccountServices.SelectUserAccount(personId);
            if (accountId != 0)
            {
                DoUserPage(accountId);
            }
            else
            {
                DoUserPage(AccountServices.CreateAccount(personId));
            }
        }

        public static void DoUserPage(int accountId)
        {
            bool isEscape;
            Account account;
            account = AccountServices.InitializeAccount(accountId);
            do
            {
                WriteLine($"Yor balance is {account.Balance}");
                WriteLine("Choose some action to continue.");
                AccountServices.ChooseAccountForAction(account);
                isEscape = KeyboardInput.EnterExitKey();
            }
            while (!isEscape);
        }

        public static void DoUserChoisePage(int personId)
        {
            int accountId = AccountServices.SelectUserAccount(personId);
            if (accountId > 0)
            {
                DoUserPage(accountId);
            }
            else
            {
                DoExitOrRegisterAccountChoise(DoEnterExitOrRegisterAccountChoise(), personId);
            }
        }

        public static char DoEnterExitOrRegisterAccountChoise()
        {
            var key = new ConsoleKeyInfo();
            bool isEOrR;
            do
            {
                WriteLine("You haven't accounts. Do you whant exit or register new account? e/r");
                key = ReadKey();
                isEOrR = Checks.IsKey(key, ConsoleKey.E, ConsoleKey.R);
            }
            while (!isEOrR);
            
            return key.KeyChar;
        }

        public static void DoExitOrRegisterAccountChoise(char symbol, int personId)
        {
            if (symbol == 'e')
            {
                Run();
            }
            else if (symbol == 'r')
            {
                DoUserPage(AccountServices.CreateAccount(personId));
            }
        }
    }
}
