using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Infrastructure;

namespace BankApp.Core
{
    public class CheckingAccount : Account
    {
        public CheckingAccount() {}

        public override void Create(string accountName, int personId)
        {
            using (var context = new BankDbConnection())
            {
                var account = new AccountsTable
                {
                    AccountName = accountName,
                    AccountTypeId = 1,
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
