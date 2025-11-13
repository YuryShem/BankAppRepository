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
        public void TransferMoney(int accountId);
        public void Deposit(int accountId);
        public void DoWithdraw(Account account);
        public void GetBalance(Account account);
    }
}
