using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Roulette
{
    public class User
    {
        public ObjectId Id { get; set; }
        [BsonIgnore]
        public string Identificator { get => Id.ToString(); set { Id = ObjectId.Parse(value); } }
        public string Identification { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
    }
}
