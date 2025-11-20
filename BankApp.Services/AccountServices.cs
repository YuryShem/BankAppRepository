using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Core;
using BankApp.Infrastructure;
using BankApp.Shared;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BankApp.Services
{
    public class AccountServices
    {
        public static int SelectUserAccount(int personId)
        {
            using (var context = new BankDbConnection())
            {
                var personAccounts = context.Accounts.Where(a => a.PersonId == personId).ToList(); 
                if (personAccounts.Count > 0)
                {
                    Console.WriteLine($"You have {personAccounts.Count} account(s):");
                    foreach(var account in personAccounts)
                    {
                        Console.WriteLine($"{personAccounts.IndexOf(account) + 1}. {account.AccountName}");
                    }

                    int accountIndex = EnteringData.InputAnyNumberChoise(personAccounts.Count, OutputData.userActionChoise);
                    if (accountIndex > 0)
                    {
                        accountIndex--;
                        return personAccounts[accountIndex].AccountId;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }               
                
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
                account.CreatedAt = dbAccount.TimeOfCreation;
                account.Person = PersonServices.GetPersonData(dbAccount.PersonId);
            }

            return account;
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

        public static void ChooseCheckingAccountAction(Account account)
        {
            int choiseNumber = EnteringData.InputAnyNumberChoise(4, OutputData.checkingAccountChoise);
            switch (choiseNumber)
            {
                case 1:
                    Account.GetBalance(account);
                    break;
                case 2:
                    Account.Deposit(account.AccountId);
                    break;
                case 3:
                    Account.DoWithdraw(account);
                    break;
                case 4:
                    Account.TransferMoney(account.AccountId);
                    break;
                default:
                    throw new ArgumentException("This type of operation is unavailable.");
            }
        }

        public static void ChooseSavingAccountAction(Account account)
        {
            int choiseNumber = EnteringData.InputAnyNumberChoise(3, OutputData.savingAccountChoise);
            switch (choiseNumber)
            {
                case 1:
                    Account.GetBalance(account);
                    break;
                case 2:
                    Account.Deposit(account.AccountId);
                    break;
                case 3:
                    Account.DoWithdraw(account);
                    break;
                default:
                    throw new ArgumentException("This type of operation is unavailable.");
            }
        }

        public static void ChooseBusinessAccountAction(Account account)
        {
            int choiseNumber = EnteringData.InputAnyNumberChoise(4, OutputData.businessAccountChoise);
            switch (choiseNumber)
            {
                case 1:
                    Account.GetBalance(account);
                    break;
                case 2:
                    Account.Deposit(account.AccountId);
                    break;
                case 3:
                    Account.DoWithdraw(account);
                    break;
                case 4:
                    Account.TransferMoney(account.AccountId);
                    break;
                default:
                    throw new ArgumentException("This type of operation is unavailable.");
            }
        }

        public static void ChooseAdminAccountAction(Account account)
        {

        }

        public static void ChooseAccountForAction(Account account)
        {
            switch (account.AccountTypeId)
            {
                case 1:
                    ChooseCheckingAccountAction(account);
                    break;
                case 2: 
                    ChooseSavingAccountAction(account);
                    break;
                case 3:
                    ChooseBusinessAccountAction(account);
                    break;
                case 4:
                    ChooseAdminAccountAction(account);
                    break;
                default:
                    throw new ArgumentException("This type of account is unavailable.");
            };
        }

        public static void ExecuteInterest()
        {
            using (var context = new BankDbConnection())
            {
                var accounts = context.Accounts.ToList();
                foreach (var account in accounts)
                {
                    Account.GetMonthlyFee(account.AccountId, account.AccountTypeId);
                    Account.AccrueInterest(account.AccountId, account.AccountTypeId);
                }

                context.SaveChanges();
            }
        }

        public static void ExecuteOnSpecificDay()
        {
            DateTime now = DateTime.Now;
            if (now.Day == 01 && now.TimeOfDay.Hours == 00 && now.TimeOfDay.Minutes == 00)
            {
                ExecuteInterest();
            }
        }

        public static int CreateAccount(int personId)
        {
            var account = SelectIAccount(ChooseAccountType()) ;
            int accountId = account.Create(EnteringData.EnterAccountName(), personId);
            return accountId;
        }

        public static int ChooseAccountType()
        {
            int accountType;
            accountType = EnteringData.InputAnyNumberChoise(3, OutputData.accountTypeChoise);
            return accountType;
        }

        public static IAccount SelectIAccount(int accountType)
        {
            IAccount account = accountType switch
            {
                1 => new CheckingAccount(),
                2 => new SavingAccount(),
                3 => new BusinessAccount(),
                _ => throw new Exception("This type of account is absent.")
            };

            return account;
        }
    }
}
