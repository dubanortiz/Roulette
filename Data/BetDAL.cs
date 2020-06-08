using MongoDB.Bson;
using MongoDB.Driver;
using Roulette.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.Data
{
    public class BetDAL
    {
        private readonly IMongoDatabase _database;
        Response response = new Response();
        public BetDAL()
        {
            _database = new Data.Conection().ConectionDatabase();
        }

        public Response CreateNewBet(Bet newBet) {
            Response validateBet = ValidateBet(newBet);
            if (validateBet.Status == "OK")
            {
                var Bet = _database.GetCollection<Bet>("Bet");
                Bet.InsertOne(newBet);
                response.Data = newBet.Identificator;
            }
            else
            {
                response = validateBet;
            }
            return response;
        }

        public Response ValidateBet(Bet bet)
        {
            if (bet.Money > 1000)
            {
                response.Message = "El limite de dinero son 1000 Dolares";
            } else if (bet.NumberBet < 0 && bet.NumberBet > 36)
            {
                response.Message = "El numero de la apuesta debe estar entre 0 y 36";
            } else if (bet.Color != "Rojo" && bet.Color != "Negro")
            {
                response.Message = "El color debe ser rojo o Negro";
            }
            if (response.Message != "OK")
            {
                response.Status = "Error";
            }
            return response;
        }
        public IEnumerable<Bet> GetBets(){
            return _database.GetCollection<Bet>("Bet").Find(new BsonDocument()).ToList();
        }
    }
}
