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
        private readonly IMongoCollection<RoomCategory> _roomCategory;
        public HoteInitializeSerivce(IConnectionService<RoomStatus> connectionService
            , IConnectionService<RoomCategory> roomCategory)
        {
            _roomStatus = connectionService.GetMongoCollection("RoomStatus");
            _roomCategory = roomCategory.GetMongoCollection("RoomCategory");
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
            List<RoomCategory> roomCategories = new List<RoomCategory>()
            {
                new RoomCategory()
                {
                    Category = "VIP"
                },
                new RoomCategory()
                {
                    Category ="Zwykły"
                }
            };

            _roomCategory.InsertMany(roomCategories);
        }

        public RoomStatus RoomStatus(string status)
        {
            return _roomStatus.Find(_ => _.Available == status).FirstOrDefault();
        }
    }
}
