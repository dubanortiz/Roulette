using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Roulette.Model;
using MongoDB.Bson;
namespace Roulette.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        [HttpGet("all")]
        public IEnumerable<Roulette> Get()
        {
            return new RouletteDAL().GetAllRoulettes();
        }
        [HttpGet("Open")]
        public IEnumerable<Roulette> GetRouletteOpen()
        {
            return new RouletteDAL().GetRoulettesOpen();
        }
        [HttpPost]
        public Response CreatedRoulette([FromBody] User user)
        {
            return new RouletteDAL().CreateNewRoulette(user);
        }
        [HttpPost("Activate")]
        public Response ActivateRoulette([FromBody] Roulette roulette)
        {
            return new RouletteDAL().ActivateRoulette(roulette.Identificator);
        }
    }
}
