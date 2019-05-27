using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.DAO.HotelService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;

namespace HotelManagment.Controllers
{
    public class BaseController : Controller
    {
        private readonly IWorkerSendEmail _workerSendEmail;
        protected readonly Logger logger = null;
        public BaseController(IWorkerSendEmail workerSendEmail)
        {
            _workerSendEmail = workerSendEmail;
            this.logger = LogManager.GetLogger(this.GetType().Name);
            this.logger.Info(this);

        }
    }
}