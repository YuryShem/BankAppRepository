using BankApp.Infrastructure;

namespace BankApp.Core
{
    public abstract class Account
    {
        public int AccountId { get; set; }

        public string AccountName { get; set; }

        public Person Person { get; set; }

        private string _accountType;
        public string AccountType { 
            get 
            {
                return _accountType;
            }
            set
            {
                _accountType = value;
            }
        }

        private decimal _balance;
        public decimal Balance { 
            get
            {
                return _balance;
            }
            set
            {
                _balance = value;
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
    }
}
