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

        public async Task AddRoomAsync(Room room)
        {
            room.Status = await _roomStatus.FindRoomStatusAsync(room.IDstat);
            await _room.InsertOneAsync(room);
        }

        public async Task DeleteRoomAsync(string id)
        {
            await _room.DeleteOneAsync(_ => _.ID == id);
        }

        public async Task<Room> FindOneRoomAsync(string id)
        {
            return await _room.Find(_ => _.ID == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Room>> GetRoomsAsync()
        {
            return await _room.Find(_ => true).ToListAsync();
        }

        public async Task UpdateRoomAsync(Room room, string id)
        {
            room.Status = await _roomStatus.FindRoomStatusAsync(room.IDstat);
            await _room.FindOneAndReplaceAsync(_ => _.ID == id, room);
        }
    }
}
