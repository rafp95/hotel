using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hotel.DAO.PublicModel
{
    public class Guest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Imie")]
        [BsonElement("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Nazwisko")]
        [BsonElement("Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Email")]
        [BsonElement("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Numer telefonu")]
        [BsonElement("Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Pesel")]
        [BsonElement("Pesel")]
        public string Pesel { get; set; }

    }
}
