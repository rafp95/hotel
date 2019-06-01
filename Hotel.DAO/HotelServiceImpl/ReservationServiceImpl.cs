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
        private readonly IRoomService _roomService;

        public ReservationServiceImpl(IConnectionService<Reservation> reservation
            , IRoomService roomService)
        {
            this._reservation = reservation.GetMongoCollection("Hotel.Reservation");
            _roomService = roomService;
        }

        public decimal CalculatePriceToPay(int days, decimal dayCost)
        {
            if (days == 0)
            {
                return dayCost;
            }
            else
            {
                if (days > 0)
                {
                    return days * dayCost;
                }
            }
            return 0;
        }

        public async Task SetUserIsConfirmedByEmailAsync(Reservation reservation, string id)
        {
            await _reservation.FindOneAndReplaceAsync(_ => _.ID == id, reservation);
        }

        public async Task<IEnumerable<Reservation>> FindNonConfirmClientByEmailAsync()
        {
            return await _reservation.Find(_ => _.EmailSend == false).ToListAsync();
        }

        public async Task<Reservation> FindReservationByIdAsync(string id)
        {
            return await _reservation.Find(_ => _.ID == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Reservation>> GetReservationsAsync()
        {
            return await _reservation.Find(_ => true).ToListAsync();
        }

        public async Task ReservationDelete(string id)
        {
            await _reservation.DeleteOneAsync(_ => _.ID == id);
        }

        public async Task SaveReservationAsync(Reservation reservation)
        {
            reservation.EmailSend = false;
            var room = await _roomService.FindRoomByIdAsync(reservation.Rooms.ID);
            await _roomService.UpdateRoomAsync(room, reservation.Rooms.ID);
            await _reservation.InsertOneAsync(reservation);
        }

        public async Task<Reservation> UpdateReservationAsync(Reservation reservation, string id)
        {
            var room = await _roomService.FindRoomByIdAsync(reservation.Room);
            if (reservation.IsConfirmed
                && !reservation.Unregister)
            {
                room.Status.Available = "Nie";
                reservation.FromDate = DateTime.Now;
                reservation.EmailSend = true;
            }
            else
            {
                if (reservation.Unregister)
                {
                    reservation.ToDate = DateTime.Now;
                    room.Status.Available = "Tak";
                    reservation.EmailSend = true;
                }
                else
                {
                    reservation.EmailSend = false;
                }
               
            }

            await _roomService.UpdateRoomAsync(room, reservation.Rooms.ID);
            return await _reservation.FindOneAndReplaceAsync(_ => _.ID == id, reservation);
        }
    }
}
