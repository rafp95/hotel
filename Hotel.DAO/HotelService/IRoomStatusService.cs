using Hotel.DAO.PublicModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAO.HotelService
{
    public interface IRoomStatusService
    {
        Task<IEnumerable<RoomStatus>> GetStatusesAsync();
        Task <RoomStatus> FindRoomStatusAsync(string id);
    }
}
