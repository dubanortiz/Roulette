using MongoDB.Bson;
using MongoDB.Driver;
using Roulette.Data;
using Roulette.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette
{
    public class RouletteDAL
    {
        private readonly IMongoDatabase _database;
        Response response = new Response();
        public RouletteDAL()
        {
            _database = new Data.Conection().ConectionDatabase();
        }

        public Response CreateNewRoulette(User user)
        {
            Response userResponse = new UserDAL().ValidateIdUser(user);
            if (userResponse.Status=="OK")
            {
                User UserCreator = (User)userResponse.Data;
                Roulette NewRoulette = new Roulette()
                {
                    Date = DateTime.Now,
                    User = UserCreator.Identificator
                };
                var Roulettes = _database.GetCollection<Roulette>("Roulette");
                Roulettes.InsertOne(NewRoulette);
                response.Data = NewRoulette.Identificator;
            }
            else
            {
                response.Status = userResponse.Status;
                response.Message = userResponse.Message;
            }

            return response;
        }

        public List<Roulette> GetAllRoulettes()
        {
            return  _database.GetCollection<Roulette>("Roulette").Find(new BsonDocument()).ToList();
        }
        public List<Roulette> GetRoulettesOpen()
        {
            return _database.GetCollection<Roulette>("Roulette").Find(x =>x.State==true).ToList();
        }
        public Response ActivateRoulette(string rouleteId)
        {
            try
            {
                Roulette Old = _database.GetCollection<Roulette>("Roulette").Find(x => x.Id == ObjectId.Parse(rouleteId)).Single();
                Old.State = true;
                _database.GetCollection<Roulette>("Roulette").ReplaceOne(x => x.Id == Old.Id, Old);
            }
            catch(Exception e)
            {
                response.Status = "Error";
                response.Message = "Error al Modificar el estado de la ruleta"+e;
            }
            
            return response;
        }

        public Response validateRoulette(string IdRoulette)
        {
            try
            {
                Roulette roulette = _database.GetCollection<Roulette>("Roulette").Find(x => x.Id == ObjectId.Parse(IdRoulette)).Single();
                if (!roulette.State)
                {
                    response.Status = "Error";
                    response.Message = "Esta ruleta se encuentra Desactivada";
                }
            }
            catch (Exception e)
            {
                response.Status = "Error";
                response.Message = "Error al Consultar la ruleta"+ e;
            }

            return response;
        }
    }
}
