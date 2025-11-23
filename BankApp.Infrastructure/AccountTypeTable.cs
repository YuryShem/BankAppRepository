using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Column("TransferFee")]
        public decimal TransferFee { get; set; }

        [Column("Overdraft")]
        public decimal Overdraft {  get; set; }
    }
}