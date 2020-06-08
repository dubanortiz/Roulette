using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Roulette
{
    public class Roulette
    {
        [BsonId]
        public ObjectId Id { get; set; }        
        [BsonIgnore]
        public string Identificator { get => Id.ToString(); set { Id = ObjectId.Parse(value); } }
        public DateTime Date { get; set; }      
        public Boolean State { get; set; }
        [BsonRequired]
        private ObjectId UserCreator;
        [BsonIgnore]
        public string User { get => this.UserCreator.ToString(); set { UserCreator = ObjectId.Parse(value); } }
        public Roulette()
        {
            State = false;
        }
    }
}
