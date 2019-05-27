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
    public class RoomController : BaseController
    {
        private readonly IRomService _romService;
        private readonly IRoomStatusService _roomStatusService;

        public RoomController(IRomService romService
            , IRoomStatusService roomStatusService
            , IWorkerSendEmail workerSendEmail) : base(workerSendEmail)
        {
            _romService = romService;
            _roomStatusService = roomStatusService;

        }

        // GET: Room
        public async Task<ActionResult> Index()
        {
            return View(await _romService.GetRoomsAsync());
        }

        // GET: Room/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Room/Create
        public async Task<ActionResult> Create()
        {
            await StatusRoom();
            return View();
        }

        // POST: Room/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(include: "Amount,Capacity,Description,RoomNr,Status")] Room room)
        {
            try
            {
                // TODO: Add insert logic here
                await _romService.AddRoomAsync(room);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Room/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            await StatusRoom();
            return View(await _romService.FindOneRoomAsync(id));
        }

        private async Task<dynamic> StatusRoom()
        {
            return ViewBag.Status = new SelectList(await _roomStatusService.GetStatusesAsync(), "Available", "Available");
        }

        // POST: Room/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, [Bind(include: "ID,Amount,Capacity,Description,RoomNr,Status")] Room room)
        {
            try
            {
                await StatusRoom();
                // TODO: Add update logic here
                await _romService.UpdateRoomAsync(room, id);
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
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                // TODO: Add delete logic here
                await _romService.DeleteRoomAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}