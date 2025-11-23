using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
