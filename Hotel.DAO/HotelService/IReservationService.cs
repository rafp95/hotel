using Hotel.DAO.PublicModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAO.HotelService
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetReservationsAsync();
        Task SaveReservationAsync(Reservation reservation);
        Task<Reservation> FindReservationByIdAsync(string id);
    }
}
