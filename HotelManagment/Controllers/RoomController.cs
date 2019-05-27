using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.DAO.HotelService;
using Hotel.DAO.PublicModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelManagment.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRomService _romService;
        private readonly IRoomStatusService _roomStatusService;

        public RoomController(IRomService romService
            , IRoomStatusService roomStatusService)
        {
            _romService = romService;
            _roomStatusService = roomStatusService;
            
        }

        // GET: Room
        public ActionResult Index()
        {
            return View(_romService.GetRooms());
        }

        // GET: Room/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            StatusRoomList();
            return View();
        }

        // POST: Room/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(include: "Amount,Capacity,Description,RoomNr,ShortName")] Room room)
        {
            try
            {
                // TODO: Add insert logic here
                _romService.AddRoom(room);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Room/Edit/5
        public ActionResult Edit(string id)
        {
            StatusRoomList();
            return View(_romService.FindOneRoom(id));
        }

        private dynamic StatusRoomList()
        {
            return ViewBag.Status = new SelectList(_roomStatusService.GetStatuses(), "ShortName", "LongName");
        }

        // POST: Room/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, [Bind(include: "ID,Amount,Capacity,Description,RoomNr,ShortName")] Room room)
        {
            try
            {
                // TODO: Add update logic here
                _romService.UpdateRoom(room, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Room/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Room/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            try
            {
                // TODO: Add delete logic here
                _romService.DeleteRoom(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}