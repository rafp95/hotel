using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.DAO.HotelService;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagment.Controllers
{
    public class BaseController : Controller
    {
        private readonly IWorkerSendEmail _workerSendEmail;
        public BaseController(IWorkerSendEmail workerSendEmail)
        {
            _workerSendEmail = workerSendEmail;
            
        }
    }
}