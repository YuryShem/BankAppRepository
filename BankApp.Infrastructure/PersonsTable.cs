using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApp.Infrastructure
{
    public class PersonsTable
    {
        [Key]
        public int PersonId { get; set; }
        [Column ("Name")]
        public string Name { get; set; }
        [Column ("Surname")]
        public string Surname { get; set; }
    }
}
