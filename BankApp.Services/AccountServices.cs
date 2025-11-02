using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Core;
using BankApp.Infrastructure;
using BankApp.Shared;

namespace BankApp.Services
{
    public class AccountServices
    {
        public static int SelectUserAccount(int personId)
        {
            using (var context = new BankDbConnection())
            {
                var personAccounts = context.Accounts.Where(a => a.PersonId == personId).ToList(); //.FirstOrDefault();
                if (personAccounts.Count > 0)
                {
                    Console.WriteLine($"You have {personAccounts.Count} account(s):");
                    foreach(var account in personAccounts)
                    {
                        Console.WriteLine($"{personAccounts.IndexOf(account) + 1}. {account.AccountName}");
                    }
                }
               
                int accountIndex = KeyboardInput.InputAccountChoise(personAccounts.Count);
                accountIndex--;
                return personAccounts[accountIndex].AccountId;
            }
        }

        public static Account InitializeAccount(int accountId)
        {
            Account account;
            using (var context = new BankDbConnection())
            {
                var dbAccount = context.Accounts.Find(accountId);
                account = SelectAccount(dbAccount.AccountTypeId);

                account.AccountId = accountId;
                account.AccountName = dbAccount.AccountName;
                //update with edits
                //account.AccountType = GetAccountType(dbAccount.AccountTypeId);
                account.CreatedAt = dbAccount.TimeOfCreation;
                account.Person = PersonServices.GetPersonData(dbAccount.PersonId);
                //update with edits
                //account.Balance = GetAccountBalance(dbAccount.AccountId);
            }

            return account;
        }
        // delete method
        public static decimal GetAccountBalance(int accountId)
        {
            using (var context = new BankDbConnection())
            {
                var accountBalance = context.AccountBalance.Where(a => a.AccountId == accountId).First();
                return accountBalance.Balance;
            }
        }
        // delete method
        public static string GetAccountType(int accountTypeId)
        {
            using (var context = new BankDbConnection())
            {
                var accountType = context.AccountType.Find(accountTypeId);
                return accountType.AccountType;
            }
        }


        public static Account SelectAccount(int accountType)
        {
            Account account = accountType switch
            {
                1 => new CheckingAccount(), 
                2 => new SavingAccount(),
                3 => new BusinessAccount(),
                _ => throw new Exception("This type of account is absent.")
            };

            return account;
        }

        public static void AccontOutput(Account account)
        {
            IAccount account1 = new CheckingAccount();
            Console.WriteLine($"{account.AccountId}, {account.AccountName}, {account.AccountType}, {account.Person.Name}, {account.Person.Surname}, {account.CreatedAt}, {account.Balance}");
        }
        // new output
        public static void AccountOutputNew(Account account)
        {
            Console.WriteLine($"Welcome {account.Person.Name} {account.Person.Surname}.");
            //Console.WriteLine($"Account \"{account.AccountName}\" have balance {GetBalance():C}");
        }

        public static void ChooseCheckingAccountAction()
        {

        }

        public static void ChooseSavingAccountAction()
        {

        }

        public static void ChooseBusinessAccountAction()
        {

        }

        public static void ChooseAdminAccountAction()
        {

        }

        public static void ChooseAccountForAction(int accountTypeId)
        {
            switch (accountTypeId)
            {
                case 1:
                    ChooseCheckingAccountAction();
                    break;
                case 2: 
                    ChooseSavingAccountAction();
                    break;
                case 3:
                    ChooseBusinessAccountAction();
                    break;
                case 4:
                    ChooseAdminAccountAction();
                    break;
                default:
                    throw new ArgumentException("Error with type of account.");
            };
        }
    }
}
