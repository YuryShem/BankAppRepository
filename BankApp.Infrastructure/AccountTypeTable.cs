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
        public int TypeId {  get; set; }

        [Column ("AccType")]
        public string AccountType { get; set; }
        
        //public virtual ICollection<AccountsTable> Accounts { get; set; }

        //public AccountTypeTable()
        //{
        //    this.Accounts = new HashSet<AccountsTable>();
        //}
    }
}