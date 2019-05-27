using Hotel.DAO.HotelService;
using Hotel.DAO.PublicModel;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.DAO.HotelServiceImpl
{
    public class RoomStatusImpl : IRoomStatusService
    {
        private readonly IMongoCollection<RoomStatus> _conntection;

        public RoomStatusImpl(IConnectionService<RoomStatus> connectionService)
        {
            _conntection = connectionService.GetMongoCollection("RoomStatus");
        }

        public RoomStatus FindRoomStatus(string id)
        {
            return _conntection.Find(_ => _.IDstat == id).FirstOrDefault();
        }

        public List<RoomStatus> GetStatuses()
        {
            return _conntection.Find(_ => true).ToList(); 
        }
    }
}
