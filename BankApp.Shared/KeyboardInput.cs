using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using BankApp.Infrastructure;

namespace BankApp.Shared
{
    public class KeyboardInput
    {
        public static int InputAccountChoise(int actionsCount)
        {
            bool isCorrect;
            string number;
            do
            {
                WriteLine("Enter a number of account to work or '0' to create new account:");
                number = ReadLine();
                isCorrect = Checks.IsAccountChoiseNumber(number, actionsCount);
            }
            while (isCorrect);

            return Convert.ToInt16(number);
        }

        public static int InputTypeAccountChoise(int actionsCount, string message)
        {
            bool isCorrect;
            string number;
            do
            {
                WriteLine(message);
                number = ReadLine();
                isCorrect = Checks.IsNumber(number, actionsCount);
            }
            while (isCorrect);

            return Convert.ToInt32(number);
        }

        public static void OutputIfNotCorrectValue(bool isCorrect)
        {
            if (!isCorrect)
            {
                WriteLine("You entered incorrect data. Please try again.");
            }
        }

        public static void OutputIfNotCorrectValue()
        {
            WriteLine("You entered incorrect data. Please try again.");
        }
        public static string OutputStringIfNotCorrectValue()
        {
            return "You entered incorrect data. Please try again."; 
        }

        public static void OutputSuccessOperation()
        {
            WriteLine("Carried out successfully.");
        }

        public static uint EnterIBAN()
        {
            bool isUint;
            uint number;

            do
            {
                Console.Write("Enter the account IBAN where you want to transfer the ammount: ");
                isUint = uint.TryParse(Console.ReadLine(), out number);
                OutputIfNotCorrectValue(isUint);
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
                OutputIfNotCorrectValue(isDecimal);
            }
            while (!isDecimal);

            return amount;
        }

        public static bool EnterExitKey()
        {
            var key = new ConsoleKeyInfo();
            bool isKey;

            WriteLine("Enter 'esc' to exit or any other key to continue.");
            isKey = Checks.IsKey(key, ConsoleKey.Escape);

            return isKey;
        }

        public const string checkingAccountChoise = "1. View balance." + "/n2. Account replenishment." + 
            "/n3. Cash withdrawal." + "/n4. Transfer to other cash.";

        public const string savingAccountChoise = "1. View balance." + "/n2. Account replenishment." + "/n3. Cash withdrawal.";

        public const string businessAccountChoise = "1. View balance." + "/n2. Account replenishment." +
            "/n3. Cash withdrawal." + "/n4. Transfer to other cash.";
    }
}
