using BankApp.Infrastructure;

namespace BankApp.Core
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public static void Create(string name, string surname)
        {
            using (var context = new BankDbConnection())
            {
                var person = new PersonsTable
                {
                    Name = name,
                    Surname = surname
                };

                context.Persons.Add(person);
                context.SaveChanges();
            }
        }

        //public static void Update(int personId)
        //{

        //}

        public static void Remove(int accountId)
        {
            using (var context = new BankDbConnection())
            {
                var person = context.Persons.Find(accountId);

                context.Persons.Remove(person);
                context.SaveChanges();
            }
        }
    }
}
