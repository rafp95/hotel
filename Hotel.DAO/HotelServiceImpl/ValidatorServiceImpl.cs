using Hotel.DAO.HotelService;
using Hotel.DAO.PublicModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.DAO.HotelServiceImpl
{
    public class ValidatorServiceImpl : IValidatorService
    {
        public int DateBetweenDays(DateTime from, DateTime now)
        {
            return (int)Math.Round(new DateTime(from.Year,from.Month,from.Day)
                .Subtract(new DateTime(now.Year, now.Month,now.Day)).TotalDays);
        }

        public bool DateIsInValid(Reservation reservation, DateTime now)
        {
            return new DateTime(reservation.FromDate.Year, reservation.FromDate.Month, reservation.FromDate.Day)
                    < new DateTime(now.Year, now.Month, now.Day)
                    || new DateTime(reservation.ToDate.Year, reservation.ToDate.Month, reservation.ToDate.Day)
                    < new DateTime(now.Year, now.Month, now.Day)
                    || new DateTime(reservation.FromDate.Year, reservation.FromDate.Month, reservation.FromDate.Day) >
                    new DateTime(reservation.ToDate.Year, reservation.ToDate.Month, reservation.ToDate.Day);
        }
    }
}
