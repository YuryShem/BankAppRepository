using BankApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Core
{
    public class SavingAccount : Account, IAccount
    {
        public override void Create(string accountName, int personId)
        {
            using (var context = new BankDbConnection())
            {
                var account = new AccountsTable
                {
                    AccountName = accountName,
                    AccountTypeId = 2,
                    PersonId = personId,
                    TimeOfCreation = DateTime.Now
                };
                context.Accounts.Add(account);
                context.SaveChanges();

                var balance = new AccountBalanceTable
                {
                    AccountId = account.AccountId
                };
                context.AccountBalance.Add(balance);
                context.SaveChanges();
            }
        }
    }
}
