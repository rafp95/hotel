using Hotel.DAO.PublicModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.DAO.HotelService
{
    public interface IRoomStatusService
    {
        List<RoomStatus> GetStatuses();
        RoomStatus FindRoomStatus(string id);
    }
}
