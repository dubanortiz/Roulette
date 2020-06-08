﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Roulette.Model;
using MongoDB.Bson;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Roulette.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        // GET: <Bet>
        [HttpGet("all")]
        public IEnumerable<Roulette> Get()
        {
            return new RouletteDAL().GetAllRoulettes();
        }
        // GET: <Bet>
        [HttpGet("Open")]
        public IEnumerable<Roulette> GetRouletteOpen()
        {
            return new RouletteDAL().GetRoulettesOpen();
        }

        // POST <Bet>
        [HttpPost]
        public Response CreatedRoulette([FromBody] User user)
        {
            return new RouletteDAL().CreateNewRoulette(user);
        }
        // POST <Bet>
        [HttpPost("Activate")]
        public Response ActivateRoulette([FromBody] Roulette roulette)
        {
            return new RouletteDAL().ActivateRoulette(roulette.Identificator);
        }
    }
}