using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Infrastructure;
using BankApp.Shared;

namespace BankApp.Core
{
    public interface IAccount
    {
        public void TransferMoney(int accountId)
        {
            try
            {
                decimal amount = KeyboardInput.EnterAmount();
                uint iban = KeyboardInput.EnterIBAN();
                using (var context = new BankDbConnection())
                {
                    var outputAccount = context.Accounts.Find(accountId);
                    var inputAccount = context.Accounts.Where(a => a.IBAN == iban).First();
                    var outputBalance = context.AccountBalance.Where(a => a.AccountId == outputAccount.AccountId).First();
                    var inputBalance = context.AccountBalance.Where(a => a.AccountId == inputAccount.AccountId).First();
                    outputBalance.Balance -= amount;
                    inputBalance.Balance += amount;
                    context.SaveChanges();
                }

                KeyboardInput.OutputSuccessOperation();
            }
            catch
            {
                KeyboardInput.OutputIfNotCorrectValue();
            }
        }
        
        public void Withdraw(int accountId)
        {
            decimal amount = KeyboardInput.EnterAmount();
            using (var context = new BankDbConnection())
            {
                var balance = context.AccountBalance.Where(a => a.AccountId == accountId).First();

                balance.Balance -= amount;
                context.SaveChanges();
            }
        }

        public void DoWithdraw(Account account)
        {
            if (account.AccountTypeId == 2)
            {
                if ((DateTime.Now - account.CreatedAt).TotalDays > 365)   // add days to const or database
                {
                    Withdraw(account.AccountId);
                }
                else
                {
                    Console.WriteLine("Saving period isn't passed. Withdraw is blocked.");
                }
            }
            else
            {
                Withdraw(account.AccountId);
            }
        }

    }
}
