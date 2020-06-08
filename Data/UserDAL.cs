using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Roulette.Data
{
    public class UserDAL
    {
        private readonly IMongoDatabase _database;
        public UserDAL()
        {
            _database = new Data.Conection().ConectionDatabase();
        }
        public Response ValidateIdUser(User user)
        {
            var Users = _database.GetCollection<User>("User");
            Response response = new Response();
            try
            {
                response.Data = Users.Find<User>(x=>x.Id==user.Id).Single();
            }
            catch(Exception e)
            {
                response.Message = "User not found. " + e.Message;
                response.Status = "Error";
            }
            return response;
        }
    }
}