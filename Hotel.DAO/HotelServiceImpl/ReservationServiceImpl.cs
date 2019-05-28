using Hotel.DAO.HotelService;
using Hotel.DAO.PublicModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAO.HotelServiceImpl
{
    public class ReservationServiceImpl : IReservationService
    {

        private readonly IMongoCollection<Reservation> _reservation;

        public ReservationServiceImpl(IConnectionService<Reservation> reservation)
        {
            this._reservation = reservation.GetMongoCollection("Reservation");
        }

        public async Task<IEnumerable<Reservation>> GetReservationsAsync()
        {
            return await _reservation.Find(_ => true).ToListAsync();
        }
    }
}
