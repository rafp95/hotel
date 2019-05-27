using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hotel.DAO.PublicModel
{
    public class RoomCategory
    {
        [BsonId]
        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "Kategoria")]
        public string Category { get; set; }
    }
}
