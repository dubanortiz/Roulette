using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roulette.Data;
using Roulette.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Roulette.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        // POST BetController
        [HttpPost]
        public Response CreatedBet([FromBody] Bet bet)
        {
            return new BetDAL().CreateNewBet(bet);
        }

        // GET BetController
        [HttpGet]
        public IEnumerable<Bet> Get()
        {
            return new BetDAL().GetBets();
        }

        // GET BetController
        [HttpGet("{Id}")]
        public IEnumerable<Bet> GetById(string Id)
        {
            return new BetDAL().GetBets(Id);
        }
    }
}
