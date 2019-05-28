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
    public class ReservationController : Controller
    {
        private readonly IRomService _roomService;

        public ReservationController(IRomService roomService)
        {
            _roomService = roomService;
        }

        // GET: Reservation
        public ActionResult Index()
        {
            return View();
        }

        // GET: Reservation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: Reservation/Create
        public async Task<ActionResult> Create()
        {
            //ViewBag.Room = new SelectList(await _roomService.FindAvaiableRoomAsync(), "ID", "Category");

            List<SelectListItem> selectListItems = await RoomAvaiable();
            ViewBag.Room = selectListItems;
            return View();
        }

        private async Task<List<SelectListItem>> RoomAvaiable()
        {
            var pom = await _roomService.FindAvaiableRoomAsync();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var item in pom)
            {
                SelectListItem selectListItem = new SelectListItem()
                {
                    Text = $"Opis = {item.Description} " +
                    $"Cena = {item.Amount} " +
                    $"VIP = {item.Category.Category} " +
                    $"Osób = {item.Capacity}",
                    Value = item.ID,
                    Selected =  string.IsNullOrEmpty(item.ID) ? true : false
                };
                selectListItems.Add(selectListItem);

            }

            return selectListItems;
        }

        // POST: Reservation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Reservation reservation)
        {
            try
            {
                List<SelectListItem> selectListItems = await RoomAvaiable();
                ViewBag.Room = selectListItems;
                // TODO: Add insert logic here
                if (string.IsNullOrEmpty(reservation.GuestID)){
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Reservation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reservation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Reservation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reservation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}