using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAO.HotelService
{
    public interface IWorkerSendEmail
    {
        Task SendEmail(string from, string to, string descr);
    }
}
