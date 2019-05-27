using Hotel.DAO.HotelService;
using Hotel.DAO.PublicModel;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAO.HotelServiceImpl
{
    public class RoomStatusImpl : IRoomStatusService
    {
        private readonly IMongoCollection<RoomStatus> _conntection;

        public RoomStatusImpl(IConnectionService<RoomStatus> connectionService)
        {
            _conntection = connectionService.GetMongoCollection("RoomStatus");
        }

        public async Task<RoomStatus> FindRoomStatusAsync(string id)
        {
            return await _conntection.Find(_ => _.Available == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<RoomStatus>> GetStatusesAsync()
        {
            return await _conntection.Find(_ => true).ToListAsync(); 
        }
    }
}
