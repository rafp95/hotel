using Hotel.DAO.HotelService;
using Hotel.DAO.PublicModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAO.HotelServiceImpl
{
    public class RoomCategoryServiceImpl : IRoomCateggoryService
    {
        private readonly IMongoCollection<RoomCategory> _room;

        public RoomCategoryServiceImpl(IConnectionService<RoomCategory> room)
        {
            _room = room.GetMongoCollection("RoomCategory");
        }

        public async Task<IEnumerable<RoomCategory>> GetRoomCateggoriesAsync()
        {
            return await _room.Find(_ => true).ToListAsync();
        }
    }
}
