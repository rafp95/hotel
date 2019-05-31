using Hotel.DAO.Infrastucture;
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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        [DateTime]
        public DateTime FromDate { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Do")]
        [BsonElement("ToDate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        [DateTime]
        public DateTime ToDate { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Gosc")]
        [BsonElement("GoscID")]
        public string GuestID { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Gość")]
        [BsonElement("Gosc")]
        public Guest Guest { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Pokój")]
        [BsonElement("PokojID")]
        public string Room { get; set; }

        [BsonElement("EmailSend")]
        public bool EmailSend { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Room")]
        [BsonElement("Pokój")]
        public Room Rooms { get; set; }

        [Display(Name = "Czy chcesz wyrejestrować gościa")]
        [BsonElement("Unregister")]
        public bool Unregister { get; set; }
    }
}
