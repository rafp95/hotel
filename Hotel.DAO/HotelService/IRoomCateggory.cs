using Hotel.DAO.PublicModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAO.HotelService
{
    public interface IRoomCateggory
    {
        Task<IEnumerable<RoomCategory>> GetRoomCateggoriesAsync();
    }
}
