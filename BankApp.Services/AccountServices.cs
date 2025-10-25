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
                account.AccountType = GetAccountType(dbAccount.AccountTypeId);
                account.CreatedAt = dbAccount.TimeOfCreation;
                account.Person = PersonServices.GetPersonData(dbAccount.PersonId);
                account.Balance = GetAccountBalance(dbAccount.AccountId);
            }

            return account;
        }

        public static decimal GetAccountBalance(int accountId)
        {
            using (var context = new BankDbConnection())
            {
                var accountBalance = context.AccountBalance.Where(a => a.AccountId == accountId).First();
                return accountBalance.Balance;
            }
        }

        public static string GetAccountType(int accountTypeId)
        {
            using (var context = new BankDbConnection())
            {
                var accountType = context.AccountTypes.Find(accountTypeId);
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
            Console.WriteLine($"{account.AccountId}, {account.AccountName}, {account.AccountType}, {account.Person.Name}, {account.Person.Surname}, {account.CreatedAt}, {account.Balance}");
        }
    }
}
