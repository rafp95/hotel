using Hotel.DAO.PublicModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.DAO.HotelService
{
    public interface IValidatorService
    {
        bool DateIsValid(Reservation from, DateTime now);
    }
}
