using Hotel.DAO.PublicModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.DAO.Initializer
{
    public interface IHotelInitialize
    {
        void InitRoomStatus();
        RoomStatus RoomStatus(string status);
    }
}
