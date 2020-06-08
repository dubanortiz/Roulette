using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roulette.Data;
using Roulette.Model;
namespace Roulette.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        [HttpPost]
        public Response CreatedBet([FromBody] Bet bet)
        {
            return new BetDAL().CreateNewBet(bet);
        }
        [HttpGet]
        public IEnumerable<Bet> Get()
        {
            return new BetDAL().GetBets();
        }
        [HttpGet("{Id}")]
        public IEnumerable<Bet> GetById(string Id)
        {
            return new BetDAL().GetBets(Id);
        }
    }
}
