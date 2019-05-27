using Hotel.DAO.PublicModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAO.HotelService
{
    public interface IRomService
    {
        List<Room> GetRooms();
        Room FindOneRoom(string id);
        void AddRoom(Room room);
        void UpdateRoom(Room room, string id);
        void DeleteRoom(string id);
    }
}
