using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.DAO.HotelService;
using Hotel.DAO.PublicModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagment.Controllers
{
    public class GuestController : BaseController
    {
        private readonly IGuestService _guestService;

        public GuestController(IGuestService guestService,
            IWorkerSendEmailService workerSendEmailService): base(workerSendEmailService)
        {
            _guestService = guestService;
        }



        // GET: Guest
        public async Task<ActionResult> Index()
        {

            return View(await _guestService.GetQuestsAsync());
        }

        // GET: Guest/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Guest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Guest/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Guest guest)
        {
            try
            {
                // TODO: Add insert logic here
                await _guestService.AddQuestAsync(guest);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Guest/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            return View(await _guestService.FindOneGestAsync(id));
        }

        // POST: Guest/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, Guest guest)
        {
            try
            {
                // TODO: Add update logic here
                await _guestService.UpdateQuest(guest, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Guest/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Guest/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                // TODO: Add delete logic here
                await _guestService.DeleteQuestAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}