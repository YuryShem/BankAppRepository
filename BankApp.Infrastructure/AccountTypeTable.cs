using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Infrastructure
{
    public class AccountTypeTable
    {
        [Key]
        public int AccountTypeId {  get; set; }

        [Column ("AccType")]
        public string AccountType { get; set; }

        [Column("MonthlyFee")]
        public decimal MonthlyFee { get; set; }

        [Column("Interest")]
        public decimal MonthlyInterest { get; set; }

        //public virtual ICollection<AccountsTable> Accounts { get; set; }

        //public AccountTypeTable()
        //{
        //    this.Accounts = new HashSet<AccountsTable>();
        //}
    }
}