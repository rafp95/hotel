using Hotel.DAO.PublicModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAO.HotelService
{
    public interface IRomService
    {
        Task<IEnumerable<Room>> GetRoomsAsync();
        Task<Room> FindOneRoomAsync(string id);
        Task AddRoomAsync(Room room);
        Task UpdateRoomAsync(Room room, string id);
        Task DeleteRoomAsync(string id);
    }
}
