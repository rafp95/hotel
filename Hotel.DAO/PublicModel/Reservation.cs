using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hotel.DAO.PublicModel
{
    public class Reservation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Od")]
        [BsonElement("FromDate")]
        [BsonDateTimeOptions]
        public DateTime FromDate { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Do")]
        [BsonElement("ToDate")]
        [BsonDateTimeOptions]
        public DateTime ToDate { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Gość")]
        [BsonElement("Gość")]
        public string GuestID { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Room")]
        [BsonElement("Pokój")]
        public string Room { get; set; }


    }
}
