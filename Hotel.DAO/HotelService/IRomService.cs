using Hotel.DAO.PublicModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAO.HotelService
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetRoomsAsync();
        Task<Room> FindRoomByIdAsync(string id);
        Task AddRoomAsync(Room room);
        Task UpdateRoomAsync(Room room, string id);
        Task UpdateRoomAsync(Room room, bool isAvaiable, string id);
        Task DeleteRoomAsync(string id);
        Task<IEnumerable<Room>> FindAvaiableRoomAsync();
        
    }
}
