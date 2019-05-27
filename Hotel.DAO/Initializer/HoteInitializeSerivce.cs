using Hotel.DAO.HotelService;
using Hotel.DAO.PublicModel;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.DAO.Initializer
{
    public class HoteInitializeSerivce : IHotelInitialize
    {
        private readonly IMongoCollection<RoomStatus> _roomStatus;
        public HoteInitializeSerivce(IConnectionService<RoomStatus> connectionService)
        {
            _roomStatus = connectionService.GetMongoCollection("RoomStatus");
        }
        public void InitRoomStatus()
        {
            List<RoomStatus> roomStatuses = new List<RoomStatus>()
            {
                new RoomStatus()
                {
                    Available = "Tak"
                },
                new RoomStatus()
                {
                    Available = "Nie"
                }
            };
            _roomStatus.InsertMany(roomStatuses);
        }

        public RoomStatus RoomStatus(string status)
        {
            return _roomStatus.Find(_ => _.Available == status).FirstOrDefault();
        }
    }
}
