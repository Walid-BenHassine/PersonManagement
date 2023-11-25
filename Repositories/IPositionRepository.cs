using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonManager.Api.Models;


namespace PersonManager.Api.Repositories
{
    public interface IPositionRepository
    {
        List<Position> SelectAll();
    }
}
