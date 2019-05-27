using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAO.HotelService
{
    public interface ISendEmailService
    {
        Task SendEmail(string email, string subject, string message);
    }

}
