using Hotel.DAO.PublicModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.DAO.HotelService
{
    public interface IValidatorService
    {
        bool DateIsInValid(Reservation from, DateTime now);
        int DateBetweenDays(DateTime from, DateTime now);
    }
}
