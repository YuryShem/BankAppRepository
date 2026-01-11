using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApp.Infrastructure
{
    public class LoginTable
    {
        [Key]
        public int Id { get; set; }

        [Column("PersonId")]
        public int PersonId { get; set; }

        [Column("Login")]
        public string Login { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        public virtual PersonsTable PersonsTable { get; set; }
    }
}
