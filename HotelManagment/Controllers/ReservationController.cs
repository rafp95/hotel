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
    public class ReservationController : BaseController
    {
        private readonly IRoomService _roomService;
        private readonly IGuestService _guestService;
        private readonly IReservationService _reservationService;
        private readonly IValidatorService _validatorService;

        public ReservationController(IRoomService roomService
            , IReservationService reservationService
            , IWorkerSendEmailService workerSendEmailService
            , IGuestService guestService
            , IValidatorService validatorService) : base(workerSendEmailService)
        {
            _roomService = roomService;
            _reservationService = reservationService;
            _guestService = guestService;
            _validatorService = validatorService;
        }

        // GET: Reservation
        public async Task<ActionResult> Index()
        {
            return View(await _reservationService.GetReservationsAsync());
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
                    Text =
                    $"Opis = {item.Description} | " +
                    $"Cena = {item.Amount} | " +
                    $"Kategoria = {item.Category.Category} | " +
                    $"Ilość osób = {item.Capacity}",
                    Value = item.ID
                };
                selectListItems.Add(selectListItem);

            }

            if (selectListItems.Count() == 0)
            {
                selectListItems.Add(new SelectListItem() { Text = "Brak wolnych pokoji" });
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
                ViewBag.NameGuest = reservation.GuestID;
                List<SelectListItem> selectListItems = await RoomAvaiable();
                ViewBag.Room = selectListItems;
                DateTime now = DateTime.Now;
                // TODO: Add insert logic here
                string[] buf = reservation.GuestID.Split(' ');
                var pesel = buf.Length >= 3 ? buf[2] : "";
                var guest = await _guestService.FindGuestByPeselAsync(pesel);
                if (guest == null)
                {
                    ViewBag.Error = $"Nie znaleziono takiego gościa";
                    return View();
                }
                else if (string.IsNullOrEmpty(reservation.Room)
                   || reservation.Room.IndexOf("Brak wolnych pokoji") > -1)
                {
                    ViewBag.Error = $"Brak wolnych pokoji";
                    return View();
                }
                else if (_validatorService.DateIsInValid(reservation, now))
                {
                    ViewBag.Error = $"Błędne daty";
                    return View();
                }
                else
                {

                    if (buf.Length < 3)
                    {
                        ViewBag.Error = $"Nie znaleziono takiego gościa";
                        return View();
                    }
                    else
                    {
                        var pom = await _guestService.FindGuestByPeselAsync(buf[2]);
                        var pom2 = await _roomService.FindRoomByIdAsync(reservation.Room);
                        reservation.GuestID = pom.ID;
                        reservation.Guest = pom;
                        reservation.Rooms = pom2;
                        await _reservationService.SaveReservationAsync(reservation);
                    }
                }

                TempData["CRUDinfo"] = "Utworzono pomyślnie";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Reservation/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            List<SelectListItem> selectListItems = await RoomAvaiable();
            ViewBag.Room = selectListItems;
            var pom = await _reservationService.FindReservationByIdAsync(id);
            return View(pom);
        }

        // POST: Reservation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Reservation reservation, string id)
        {
            try
            {
                List<SelectListItem> selectListItems = await RoomAvaiable();
                ViewBag.Room = selectListItems;
                DateTime now = DateTime.Now;
                // TODO: Add insert logic here
                if (_validatorService.DateIsInValid(reservation, now))
                {
                    ViewBag.Error = $"Błędne daty";
                    return View(reservation);
                }
                else
                {
                    var pom = await _guestService.FindGuestByIdAsync(reservation.GuestID);
                    var pom2 = await _roomService.FindRoomByIdAsync(reservation.Room);

                    if (pom2 == null)
                    {
                        ViewBag.Error = $"Wybrany pokój nie istnieje";
                        return View(reservation);
                    }
                    else
                    {
                        reservation.GuestID = pom.ID;
                        reservation.Guest = pom;
                        reservation.Rooms = pom2;
                        if (reservation.Unregister)
                        {
                            reservation.Price = _reservationService.CalculatePriceToPay(_validatorService.DateBetweenDays(reservation.FromDate, now), reservation.Rooms.Amount);
                        }
                        await _reservationService.UpdateReservationAsync(reservation, id);
                        TempData["CRUDinfo"] = "Zaktualizowno pomyślnie";
                    }
                }

            }
            catch
            {
                ViewBag.Error = $"Zostały wybrane błędne dane";
                return View(await _reservationService.FindReservationByIdAsync(id));
            }

            // TODO walidacja daty
            // TODO: Add update logic here               
            return RedirectToAction(nameof(Index));
        }


        // GET: Reservation/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Reservation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                // TODO: Add delete logic here
                await _reservationService.ReservationDelete(id);
                TempData["CRUDinfo"] = "Skasowno pomyślnie";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}