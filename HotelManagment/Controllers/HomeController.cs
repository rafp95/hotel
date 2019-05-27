using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelManagment.Models;
using Hotel.DAO.Initializer;
using Hotel.DAO.HotelService;
using Hotel.DAO.HotelServiceImpl;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hotel.DAO.PublicModel;

namespace HotelManagment.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IHotelInitialize _hotelInitialize;
        private readonly IRomService _roomService;
        private readonly IRoomStatusService _roomStatusService;

        public HomeController(IHotelInitialize hotelInitialize
            , IRomService romService
            , IRoomStatusService roomStatusService,
            IWorkerSendEmailService workerSendEmail) : base(workerSendEmail)
        {
            _hotelInitialize = hotelInitialize;
            _roomService = romService;
            _roomStatusService = roomStatusService;
        }

        public IActionResult Index()
        {
            //TODO init data
            // _hotelInitialize.InitRoomStatus();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
