using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Infrastructure
{
    public class LoginsTable
    {
        [Key]
        public int Id { get; set; }
        [Column ("PersonId")]
        public int PersonId { get; set; }
        [Column ("Login")]
        public string Login { get; set; }
        [Column ("Password")]
        public string Password { get; set; }

        public virtual PersonsTable PersonsTable { get; set; }
    }
}
