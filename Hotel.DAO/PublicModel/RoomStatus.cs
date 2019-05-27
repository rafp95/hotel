using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.DAO.PublicModel
{
    public class RoomStatus
    {
        [BsonId]
        public string IDstat { get; set; }
        public string Available { get; set; }
    }
}
