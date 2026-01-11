using static System.Console;
using BankApp.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

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

        public static void OutputUserAccountList(int personId)
        {
            using (var context = new BankDbConnection())
            {
                var personAccounts = context.Accounts.Where(a => a.PersonId == personId).ToList();

                Console.WriteLine($"You have {personAccounts.Count} account(s):");
                foreach (var account in personAccounts)
                {
                    Console.WriteLine($"{personAccounts.IndexOf(account) + 1}. {account.AccountName}");
                }
            }
        }

        public static string OutputUserAccountActionsForWebApi(int accountId)
        {
            using (var context = new BankDbConnection())
            {
                var account = context.Accounts.Find(accountId);

                string message = account.AccountTypeId switch
                {
                    1 => checkingAccountChoise,
                    2 => savingAccountChoise,
                    3 => businessAccountChoise,
                };

                return message;
            }
        }

        public static List<string> OutputUserAccountListForWebApi(int personId)
        {
            List<string> AccountsList = new List<string>();

            using (var context = new BankDbConnection())
            {
                var personAccounts = context.Accounts.Where(a => a.PersonId == personId).ToList();

                AccountsList.Add($"You have {personAccounts.Count} account(s):");
                foreach (var account in personAccounts)
                {
                    AccountsList.Add($"{personAccounts.IndexOf(account) + 1}. {account.AccountName}");
                }
            }

            return AccountsList;
        }

        public static void OutputSuccessOperation()
        {
            WriteLine("Carried out successfully.");
        }

        public static void OutputIfValueMoreOverdraft() 
        {
            WriteLine("Error. Insufficient funds.");
        }

        public const string userActionChoise = "Enter a number of account to work or '0' to create new account or exit:";

        public const string accountTypeChoise = "1. Checking account/" + "\n2. Saving account." + "\n3. BusinessAccount.";

        public const string checkingAccountChoise = "1. View balance." + "\n2. Account replenishment." + 
            "\n3. Cash withdrawal." + "\n4. Transfer to other cash." + "\n5. Change account name.";

        public const string savingAccountChoise = "1. View balance." + "\n2. Account replenishment." + "\n3. Cash withdrawal." 
            + "\n4. Change account name.";

        public const string businessAccountChoise = "1. View balance." + "\n2. Account replenishment." +
            "\n3. Cash withdrawal." + "\n4. Transfer to other cash." + "\n5. Change account name.";
    }
}
