using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using BankApp.Infrastructure;

namespace BankApp.Shared
{
    public class OutputData
    {
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

        public const string userActionChoise = "Enter a number of account to work or '0' to create new account or exit:";

        public const string accountTypeChoise = "1. Checking account/" + "/n2. Saving account." + "n/3. BusinessAccount.";

        public const string checkingAccountChoise = "1. View balance." + "/n2. Account replenishment." + 
            "/n3. Cash withdrawal." + "/n4. Transfer to other cash.";

        public const string savingAccountChoise = "1. View balance." + "/n2. Account replenishment." + "/n3. Cash withdrawal.";

        public const string businessAccountChoise = "1. View balance." + "/n2. Account replenishment." +
            "/n3. Cash withdrawal." + "/n4. Transfer to other cash.";
    }
}
