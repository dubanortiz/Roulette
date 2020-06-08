using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.Data
{
    public class Conection
    {
        public IMongoDatabase ConectionDatabase()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Roulette");

            return database;
        }
    }
}
