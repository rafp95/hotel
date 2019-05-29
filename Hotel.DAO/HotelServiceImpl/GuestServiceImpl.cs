using Hotel.DAO.HotelService;
using Hotel.DAO.PublicModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAO.HotelServiceImpl
{
    public class GuestServiceImpl : IGuestService
    {
        private readonly IMongoCollection<Guest> _guest;

        public GuestServiceImpl(IConnectionService<Guest> guest)
        {
            this._guest = guest.GetMongoCollection("Guest");
        }

        public async Task AddQuestAsync(Guest guest)
        {
            await this._guest.InsertOneAsync(guest);
        }

        public async Task DeleteQuestAsync(string id)
        {
            await this._guest.DeleteOneAsync(_ => _.ID == id);
        }

        public IEnumerable<Guest> FindGuestByName(string criteria)
        { 
            return  _guest.Find(_ => _.Name.Contains(criteria) ).ToList();
        }

        public async Task<Guest> FindGuestByIdAsync(string id)
        {
            return await this._guest.Find(_ => _.ID == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Guest>> GetQuestsAsync()
        {
            return await this._guest.Find(_ => true).ToListAsync();
        }

        public async  Task UpdateQuest(Guest guest, string id)
        {
            await this._guest.FindOneAndReplaceAsync(_ => _.ID == id, guest);
        }

        public async Task<Guest> FindGuestByPeselAsync(string pesel)
        {
            return await this._guest.Find(_ => _.Pesel == pesel).FirstOrDefaultAsync();
        }
    }
}
