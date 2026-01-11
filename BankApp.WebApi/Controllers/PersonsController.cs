using BankApp.Core;
using BankApp.Services;
using BankApp.Shared;
using BankApp.Shared.Exeptions;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.WebApi.Controllers
{
    //[Area("Persons")]
    [ApiController]
    [Route("api/[controller]")]
    //[Tags("Persons")]
    public class PersonsController : ControllerBase
    {
        private readonly ILogger<PersonsController> _logger;

        public PersonsController(ILogger<PersonsController> logger)
        {
            _logger = logger;
        }

        //[HttpGet("persons")]
        //public IEnumerable<Person> GetPerson()
        //{
        //    return Enumerable.Range(1, 2).Select(index => PersonServices.GetPersonData(index)).ToArray();
        //}

        [HttpGet("Login")]
        public Person GetPersonData(string login, string password)
        {
            IntermediateData.person = PersonServices.GetPersonData(LoginServices.LogInForWebApi(login, password));

            return IntermediateData.person;
        }

        [HttpGet("Register")]
        public Person RegisterNewPerson(string name, string surname, string login, string password)
        {
            int personId;

            if (LoginChecks.IsUniqueLogin(login))
            {
                personId = LoginServices.DoRegister(name, surname, login, password);
                IntermediateData.person = null;

                return PersonServices.GetPersonData(personId);
            }
            else
            {
                throw new LoginException();
            }
        }

        [HttpPut("UpdatePersonData")]
        public ActionResult UpdatePersonData(string name, string surname)
        {
            try
            {
                Person.Update(IntermediateData.person.Id, name, surname);
                IntermediateData.person = null;

                return Ok("Carried out successfully.");
            }
            catch
            {
                throw new LoginException();
            }
        }

        [HttpDelete("DeletePerson")]
        public ActionResult DeletePerson()
        {
            if (!Checks.IsPersonHaveAccounts(IntermediateData.person.Id))
            {
                Person.Remove(IntermediateData.person.Id);
                IntermediateData.person = null;

                return Ok("Carried out successfully.");
            }
            else
            {
                throw new LoginException();
            }
        }

        //[HttpPost("person")]
        //public Person GetPersonData([FromBody] Person person)
        //{
        //    int id = person.Id;
        //    string name = person.Name;
        //    string surname = person.Surname;

        //    return person;
        //    //return PersonServices.GetPersonData(2);
        //}

        //[HttpPost("{id}, {name}, {surname}")]
        //public Person GetPersonDataR(int id, string name, string surname)
        //{
        //    Person person = new Person()
        //    {
        //        Id = id,
        //        Name = name,
        //        Surname = surname
        //    };
        //    return person;
        //    //return PersonServices.GetPersonData(2);
        //}
    }
}
