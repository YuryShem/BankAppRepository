using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Infrastructure
{
    public class AccountBalanceTable
    {
        [Key]
        public int BalanceId { get; set; }
        [Column ("AccountId")]
        public int AccountId { get; set; }
        [Column ("Balance")]
        public decimal Balance {  get; set; }

        public virtual AccountsTable AccountsTable { get; set; }
    }
}
