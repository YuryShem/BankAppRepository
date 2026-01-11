using BankApp.Infrastructure;
using System.Xml.Serialization;

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

        public static void Update(int personId, string name, string surname)
        {
            using (var context = new BankDbConnection())
            {
                var person = context.Persons.Find(personId);

                person.Name = name;
                person.Surname = surname;

                context.SaveChanges();
            }
        }

        public static void Remove(int personId)
        {
            using (var context = new BankDbConnection())
            {
                var person = context.Persons.Find(personId);
                var login = context.Login.Where(l => l.Id == personId).First();

                context.Persons.Remove(person);
                context.Login.Remove(login);
                context.SaveChanges();
            }
        }
    }
}
