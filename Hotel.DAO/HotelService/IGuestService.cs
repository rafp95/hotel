using Hotel.DAO.PublicModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAO.HotelService
{
    public interface IGuestService
    {
        Task <IEnumerable<Guest>> GetQuestsAsync();
        Task AddQuestAsync(Guest guest);
        Task DeleteQuestAsync(string id);
        Task<Guest> FindOneGestAsync(string id);
        Task UpdateQuest(Guest guest, string id);
        IEnumerable<Guest> FindGuestByCriteria(string criteria);
    }
}
