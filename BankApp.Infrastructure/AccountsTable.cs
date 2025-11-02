using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Infrastructure
{
    public class AccountsTable
    {
        [Key]
        public int AccountId { get; set; }

        [Column ("AccountName")]
        public string AccountName { get; set; }

        [Column ("AccountTypeId")]
        public int AccountTypeId { get; set; }

        [Column ("TimeOfCreation")]
        public DateTime TimeOfCreation { get; set; }

        [Column ("PersonId")]
        public int PersonId { get; set; }

        [Column ("IBAN")]
        public long IBAN {  get; set; }

        public virtual AccountTypeTable AccountTypeTable { get; set; }

        public virtual PersonsTable PersonsTable { get; set; }


    }
}
