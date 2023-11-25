using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonManager.Api.Models;
using Microsoft.EntityFrameworkCore;


namespace PersonManager.Api.Repositories
{
    public class PositionRepository : IPositionRepository
    {

        private readonly AppDbContext db = null;

        public PositionRepository(AppDbContext db)
        {
            this.db = db;
        }

        public List<Position> SelectAll()
        {
            List<Position> data = db.Positions.FromSqlRaw("EXEC Positions_SelectAll").ToList();
            return data;
        }

    }
}
