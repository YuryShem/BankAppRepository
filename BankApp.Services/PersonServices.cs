using BankApp.Core;
using BankApp.Infrastructure;

namespace BankApp.Services
{
    public class PersonServices
    {
        public static Person GetPersonData(int personId)
        {
            Person person = new Person();

            using (var context = new BankDbConnection())
            {
                var dbPerson = context.Persons.Find(personId);

                person.Id = dbPerson.PersonId;
                person.Name = dbPerson.Name.Trim();
                person.Surname = dbPerson.Surname.Trim();
            }

            return person;
        }
    }
}
