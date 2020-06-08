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
            string host = @Environment.GetEnvironmentVariable("Host");
            string port = @Environment.GetEnvironmentVariable("Port");
            string userName = @Environment.GetEnvironmentVariable("UserName");
            string password = @Environment.GetEnvironmentVariable("Password");
            var client = new MongoClient("mongodb://"+ userName +":"+ password +"@"+ host +":"+ port );
            var database = client.GetDatabase("Roulette");

            return database;
        }
    }
}
