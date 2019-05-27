using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hotel.DAO.PublicModel
{
    public class Room
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        [Required]
        [Display(Name = "Numer pokoju")]
        [BsonElement("RoomNr")]
        public string RoomNr { get; set; }

        [Required]
        [Display(Name = "Opis pokoju")]
        [BsonElement("Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Cena za dobę")]
        [BsonElement("Amount")]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Ilość osób")]
        [BsonElement("Capacity")]
        public int Capacity { get; set; }

        [Required]
        public string ShortName { get; set; }

        [Display(Name = "Wolny")]
        [BsonElement("Status")]
        public RoomStatus Status { get; set; }
    }

}
