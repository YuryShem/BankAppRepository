using BankApp.Infrastructure;

namespace BankApp.Core
{
    public abstract class Account : IAccount
    {
        public int AccountId { get; set; }

        public string AccountName { get; set; }

        public Person Person { get; set; }

        // new method
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

        //ubdated get and removed set
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

        // updated get and set
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

        public abstract void Create(string accountName, int personId);

        public void Update(int accountId)
        {
            using (var context = new BankDbConnection())
            {
                //var accounts = context.Accounts.Where(a => a.AccountName.Contains("k")).ToList();

                var account = context.Accounts.Find(accountId);
                account.AccountName = "newName";
                context.SaveChanges();
            }
        }

        public void Remove(int accountId)
        {
            using (var context = new BankDbConnection())
            {
                var account = context.Accounts.Find(accountId);
                context.Accounts.Remove(account);
                context.SaveChanges();
            }
        }


        // new methods
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

        public static void ExecuteInterest()
        {
            using (var context = new BankDbConnection())
            {
                var accounts = context.Accounts.ToList();
                foreach (var account in accounts)
                {
                    GetMonthlyFee(account.AccountId, account.AccountTypeId);
                    AccrueInterest(account.AccountId, account.AccountTypeId);
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
    }
}
