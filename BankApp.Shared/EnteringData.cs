using BankApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace BankApp.Shared
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

        public static long CreateIBAN()
        {
            long min = 100000000000000000;
            long max = 999999999999999999;
            Random random = new Random();
            byte[] buf = new byte[8];

            random.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return Math.Abs(longRand % (max - min)) + min;
        }

        public static long CreateUniqueIBAN()
        {
            bool isUniqueIBAN;
            long iban;
            using (var context = new BankDbConnection())
            {
                do
                {
                    iban = EnteringData.CreateIBAN();
                    var accounts = context.Accounts.Where(l => l.IBAN == iban).ToList();
                    if (accounts.Count > 0)
                    {
                        isUniqueIBAN = false;
                    }
                    else
                    {
                        isUniqueIBAN = true;
                    }
                }
                while (!isUniqueIBAN);
            }

            return iban;
        }

        //public static int InputAccountChoise(int actionsCount)    // delete this method !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //{
        //    bool isCorrect;
        //    string number;
        //    do
        //    {
        //        WriteLine("Enter a number of account to work or '0' to create new account or exit:");
        //        number = ReadLine();
        //        isCorrect = Checks.IsAccountChoiseNumber(number, actionsCount);
        //    }
        //    while (!isCorrect);

        //    return Convert.ToInt16(number);
        //}

        public static int InputAnyNumberChoise(int actionsCount, string message)
        {
            bool isCorrect;
            string number;
            do
            {
                WriteLine(message);
                number = ReadLine();
                isCorrect = Checks.IsAccountChoiseNumber(number, actionsCount);
            }
            while (!isCorrect);

            return Convert.ToInt32(number);
        }

        public static uint EnterIBAN()
        {
            bool isUint;
            uint number;

            do
            {
                Console.Write("Enter the account IBAN where you want to transfer the ammount: ");
                isUint = uint.TryParse(Console.ReadLine(), out number);
                OutputData.OutputIfNotCorrectValue(isUint);
            }
            while (!isUint);

            return number;
        }

        public static decimal EnterAmount()
        {
            bool isDecimal;
            decimal amount;

            do
            {
                Console.Write("Enter the amount you want to transfer: ");
                isDecimal = decimal.TryParse(Console.ReadLine(), out amount);
                OutputData.OutputIfNotCorrectValue(isDecimal);
            }
            while (!isDecimal);

            return amount;
        }

        public static bool EnterExitKey()
        {
            //var key = new ConsoleKeyInfo();
            bool isKey;

            WriteLine("Enter 'esc' to exit or any other key to continue.");
            isKey = Checks.IsKey(ReadKey(), ConsoleKey.Escape);

            return isKey;
        }

        public static string EnterAccountName()
        {
            bool isUniqueAccountName;
            string accountName;
            do
            {
                WriteLine("Enter name of your account.");
                accountName = ReadLine();
                isUniqueAccountName = Checks.IsUniqueAccountName(accountName);
            }
            while (!isUniqueAccountName);

            return accountName;
        }
    }
}
