using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using PersonManager.Api.Models;
using Microsoft.EntityFrameworkCore;


namespace PersonManager.Api.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext db = null;

        public PersonRepository(AppDbContext db)
        {
            this.db = db;
        }

        public List<Person> SelectAll()
        {
            List<Person> data = db.Persons.FromSqlRaw("EXEC Persons_SelectAll").ToList();
            return data;
        }

        public Person SelectByID(int id)
        {
            SqlParameter p = new SqlParameter("@PersonID", id);
            Person person = db.Persons.FromSqlRaw("EXEC Persons_SelectByID @PersonID", p).ToList().SingleOrDefault();
            return person;
        }
     
        public void Insert(Person person)
        {
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter("@FirstName", person.FirstName);
            p[1] = new SqlParameter("@LastName", person.LastName);
            p[2] = new SqlParameter("@BirthDate", person.BirthDate);
            p[3] = new SqlParameter("@StartDate", person.StartDate);
            p[4] = new SqlParameter("@EndDate", person.EndDate);
            p[5] = new SqlParameter("@Position", person.Position);
            p[6] = new SqlParameter("@PersonID", SqlDbType.Int);
            p[6].Direction = ParameterDirection.Output;

             int count = db.Database.ExecuteSqlRaw("EXEC Persons_Insert @FirstName,@LastName,@BirthDate,@StartDate,@EndDate,@Position,@PersonID OUT", p); 
        }

        public void Update(Person person)
        {
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter("@PersonID", person.PersonID);
            p[1] = new SqlParameter("@FirstName", person.FirstName);
            p[2] = new SqlParameter("@LastName", person.LastName);
            p[3] = new SqlParameter("@BirthDate", person.BirthDate);
            p[4] = new SqlParameter("@StartDate", person.StartDate);
            p[5] = new SqlParameter("@EndDate", person.EndDate);
            p[6] = new SqlParameter("@Position", person.Position);

            int count = db.Database.ExecuteSqlRaw("EXEC Persons_Update @PersonID,@FirstName,@LastName,@BirthDate,@StartDate,@EndDate,@Position", p);
        }

        public void Delete(int id)
        {
            SqlParameter p = new SqlParameter("@PersonID", id);
            int count = db.Database.ExecuteSqlRaw("EXEC Persons_Delete @PersonID", p);
        }

    }
}
