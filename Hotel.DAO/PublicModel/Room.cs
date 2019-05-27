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

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Numer pokoju")]
        [BsonElement("RoomNr")]
        public string RoomNr { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Opis pokoju")]
        [BsonElement("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Cena za dobę")]
        [BsonElement("Amount")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Ilość osób")]
        [BsonElement("Capacity")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Wolny")]
        [BsonElement("Status")]
        public RoomStatus Status { get; set; }
    }

}
