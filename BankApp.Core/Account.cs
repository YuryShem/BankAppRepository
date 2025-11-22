using BankApp.Infrastructure;
using BankApp.Shared;

namespace BankApp.Core
{
    public abstract class Account
    {
        public int AccountId { get; set; }

        public string AccountName { get; set; }

        public Person Person { get; set; }

        public int AccountTypeId
        {
            get
            {
                using (var context = new BankDbConnection())
                {
                    var account = context.Accounts.Find(AccountId);
                    return account.AccountTypeId;
                }
            }
        }

        public string AccountType { 
            get 
            {
                using (var context = new BankDbConnection())
                {
                    var accountType = context.AccountType.Find(AccountTypeId);
                    return accountType.AccountType;
                }
            }
        }

        public decimal Balance { 
            get
            {
                using (var context = new BankDbConnection())
                {
                    var accountBalance = context.AccountBalance.Where(a => a.AccountId == AccountId).First();
                    return accountBalance.Balance;
                }
            }
            set
            {
                using (var context = new BankDbConnection())
                {
                    var accountBalance = context.AccountBalance.Where(a => a.AccountId == AccountId).First();
                    accountBalance.Balance = value;
                    context.SaveChanges();
                }
            }
        }

        private DateTime _createdAt;
        public DateTime CreatedAt { 
            get
            {
                return _createdAt;
            }
            set
            {
                _createdAt = value;
            }
        }

        public long IBAN { get; set; }

        public static void Update(int accountId)
        {
            using (var context = new BankDbConnection())
            {
                var account = context.Accounts.Find(accountId);
                account.AccountName = EnteringData.EnterAccountName();
                context.SaveChanges();
            }
        }

        public static void Remove(int accountId)
        {
            using (var context = new BankDbConnection())
            {
                var account = context.Accounts.Find(accountId);
                context.Accounts.Remove(account);
                context.SaveChanges();
            }
        }

        public static void GetMonthlyFee(int accountId, int accountTypeId)
        {
            using (var context = new BankDbConnection())
            {
                var balance = context.AccountBalance.Where(a => a.AccountId == accountId).First();
                var accountTypeData = context.AccountType.Find(accountTypeId);
                balance.Balance -= accountTypeData.MonthlyFee;
                context.SaveChanges();
            }
        }

        public static void AccrueInterest(int accountId, int accountTypeId)
        {
            using (var context = new BankDbConnection())
            {
                var balance = context.AccountBalance.Where(a => a.AccountId == accountId).First();
                var accountTypeData = context.AccountType.Find(accountTypeId);
                balance.Balance += (balance.Balance * accountTypeData.MonthlyInterest) / 100;
                context.SaveChanges();
            }
        }

        public static void TransferMoney(int accountId)
        {
            try
            {
                decimal amount = EnteringData.EnterAmount();
                uint iban = EnteringData.EnterIBAN();
                using (var context = new BankDbConnection())
                {
                    var outputAccount = context.Accounts.Find(accountId);
                    var inputAccount = context.Accounts.Where(a => a.IBAN == iban).First();
                    var outputBalance = context.AccountBalance.Where(a => a.AccountId == outputAccount.AccountId).First();
                    var inputBalance = context.AccountBalance.Where(a => a.AccountId == inputAccount.AccountId).First();
                    outputBalance.Balance -= (amount + GetTransferFee(outputAccount.AccountTypeId));
                    inputBalance.Balance += amount;
                    context.SaveChanges();
                }

                OutputData.OutputSuccessOperation();
            }
            catch
            {
                OutputData.OutputIfNotCorrectValue();
            }
        }

        public static void Deposit(int accountId)
        {
            try
            {
                decimal amount = EnteringData.EnterAmount();
                using (var context = new BankDbConnection())
                {
                    var balance = context.AccountBalance.Where(a => a.AccountId == accountId).First();
                    balance.Balance += amount;
                    context.SaveChanges();
                }

                OutputData.OutputSuccessOperation();
            }
            catch
            {
                OutputData.OutputIfNotCorrectValue();
            }
        }

        public static void DoWithdraw(Account account)
        {
            if (account.AccountTypeId == 2)
            {
                if ((DateTime.Now - account.CreatedAt).TotalDays > 365)   
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

        public static void GetBalance(Account account)
        {
            Console.WriteLine($"Your balance is {account.Balance}");
        }

        public static decimal GetTransferFee(int accountTypeId)
        {
            decimal fee;

            using (var context = new BankDbConnection())
            {
                var accountType = context.AccountType.Find(accountTypeId);
                fee = accountType.TransferFee;
            }

            return fee;
        }

        public static void Withdraw(int accountId)
        {
            decimal amount = EnteringData.EnterAmount();
            using (var context = new BankDbConnection())
            {
                var balance = context.AccountBalance.Where(a => a.AccountId == accountId).First();

                balance.Balance -= amount;
                context.SaveChanges();
            }
        }
    }
}
