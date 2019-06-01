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
        Task<Reservation> UpdateReservationAsync(Reservation reservation, string id);
        decimal CalculatePriceToPay(int days, decimal dayCost);
        Task<IEnumerable<Reservation>> FindNonConfirmClientByEmailAsync();
        Task ReservationDelete(string id);
        Task SetUserIsConfirmedByEmailAsync(Reservation reservation, string id);
    }

}
