using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.Model
{
    public class Bet
    {
        [BsonId]
        private ObjectId Id { get; set; }
        [BsonIgnore]
        public string Identificator { get => Id.ToString(); }
        [BsonRequired]
        public ObjectId Roulette { get; set; }
        [BsonIgnore]
        public String RouletteOwner { get => this.Roulette.ToString(); set { Roulette = ObjectId.Parse(value); } }
        //[MaxLength(1000)]
        public int Money { get; set; }
        [BsonIgnore]
        public string User { get => this.UserBet.ToString(); set { UserBet = ObjectId.Parse(value); } }
        [BsonRequired]
        private ObjectId UserBet { get; set; }
        public DateTime Date { get; set; }
        //[MaxLength(36),MinLength(0), AllowNull, BsonRequired]        
        public int NumberBet { get; set; }
        [AllowNull, BsonRequired, ]
        public string Color {get;set;}
        [BsonIgnore]
        public bool Validate { get; set; }       
        public Bet()
        {
            Date = DateTime.Now;
        }        
    }
}
