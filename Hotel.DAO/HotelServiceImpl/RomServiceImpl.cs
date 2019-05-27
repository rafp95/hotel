using Hotel.DAO.PublicModel;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAO.HotelService
{
    public class RomServiceImpl : IRomService
    {
        private readonly IMongoCollection<Room> _room;
        private readonly IRoomStatusService _roomStatus;

        public RomServiceImpl(IConnectionService<Room> room,
            IRoomStatusService roomStatus)
        {
            this._room = room.GetMongoCollection("Room");
            this._roomStatus = roomStatus;
        }

        public void AddRoom(Room room)
        {
            room.Status = _roomStatus.FindRoomStatus(room.IDstat);
            _room.InsertOne(room);
        }

        public void DeleteRoom(string id)
        {
            _room.DeleteOne<Room>(_ => _.ID == id);
        }

        public Room FindOneRoom(string id)
        {
            return _room.Find(_ => _.ID == id).FirstOrDefault();
        }

        public List<Room> GetRooms()
        {
            return _room.Find(_ => true).ToList();
        }

        public void UpdateRoom(Room room, string id)
        {
            room.Status = _roomStatus.FindRoomStatus(room.IDstat);
            _room.FindOneAndReplace(_ => _.ID == id, room);
        }
    }
}
