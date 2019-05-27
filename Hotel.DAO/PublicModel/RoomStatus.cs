using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hotel.DAO.PublicModel
{
    public class RoomStatus
    {
        [BsonId]
        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Dostepny")]
        public string Available { get; set; }
    }
}
