using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonManager.Api.Models;
using Microsoft.EntityFrameworkCore;
using PersonManager.Api.Repositories;


namespace PersonManager.Api.Controllers
{
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {

        private readonly IPersonRepository personRepository = null;

        public PersonsController(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }


        [HttpGet]
        public List<Person> Get()
        {
            return personRepository.SelectAll();
        }



        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return personRepository.SelectByID(id);
        }

        // Sauvegardent une nouvelle personne
        // Seules les personnes de moins de 150 ans peuvent être enregistrées. 
        // Sinon, renvoyez une erreur.
        [HttpPost]
        public void Post([FromBody]Person person)
        {
            if (ModelState.IsValid)
            {
             if((DateTime.Now.Year - person.BirthDate.Year) < 150){
              personRepository.Insert(person);
            }
           else {
            throw new System.Exception("Seules les personnes de moins de 150 ans peuvent être enregistrées !");
           }  
               
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Person person)
        {
            if (ModelState.IsValid)
            {
                personRepository.Update(person);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            personRepository.Delete(id);
        }
    }
}
