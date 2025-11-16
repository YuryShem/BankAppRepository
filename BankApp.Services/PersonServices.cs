using BankApp.Core;
using BankApp.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                person.Name = dbPerson.Name;
                person.Surname = dbPerson.Surname;
            }

            return person;
        }
    }
}
