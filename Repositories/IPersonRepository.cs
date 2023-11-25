using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonManager.Api.Models;


namespace PersonManager.Api.Repositories
{
    public interface IPersonRepository
    {
        List<Person> SelectAll();
        Person SelectByID(int id);
        void Insert(Person person);
        void Update(Person person);
        void Delete(int id);
    }
}
