using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.DAO.HotelService
{
    public interface IWorkerSendEmail
    {
        void SendEmail(string from, string to, string descr);
    }
}
