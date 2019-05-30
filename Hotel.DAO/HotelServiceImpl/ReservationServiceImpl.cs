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
            ,IRoomService roomService)
        {
            this._reservation = reservation.GetMongoCollection("Hotel.Reservation");
            _roomService = roomService;
        }

        public async Task<IEnumerable<Reservation>> FindNonConfirmClientByEmailAsync()
        {
            return await _reservation.Find(_ => _.EmailSend == 'n').ToListAsync();
        }

        public async Task<Reservation> FindReservationByIdAsync(string id)
        {
            return await _reservation.Find(_ => _.ID == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Reservation>> GetReservationsAsync()
        {
            return await _reservation.Find(_ => true).ToListAsync();
        }

        public async Task SaveReservationAsync(Reservation reservation)
        {
            reservation.EmailSend = 'n';
            var room = await _roomService.FindRoomByIdAsync(reservation.Rooms.ID);
            room.Status.Available = "Nie";
            await _roomService.UpdateRoomAsync(room, reservation.Rooms.ID);
            await _reservation.InsertOneAsync(reservation);
        }

        public async Task<Reservation> UpdateReservationAsync(Reservation reservation, string id)
        {
            var room = await _roomService.FindRoomByIdAsync(reservation.Rooms.ID);
            if (!reservation.Unregister)
            {
                room.Status.Available = "Nie";
            }
            else
            {
                room.Status.Available = "Tak";
                reservation.EmailSend = 't';
                reservation.ToDate = DateTime.Now;
            }

            await _roomService.UpdateRoomAsync(room, reservation.Unregister, reservation.Rooms.ID);
            return await _reservation.FindOneAndReplaceAsync(_ => _.ID == id, reservation);
        }
    }
}
