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
    public class PositionsController : ControllerBase
    {

        private readonly IPositionRepository positionRepository = null;

        public PositionsController(IPositionRepository positionRepository)
        {
            this.positionRepository = positionRepository;
        }


        [HttpGet]
        public List<Position> Get()
        {
            return positionRepository.SelectAll();
        }
    }
}
