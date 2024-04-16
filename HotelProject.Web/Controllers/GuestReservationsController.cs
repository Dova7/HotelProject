using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using HotelProject.Repository.MVCRepos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelProject.Web.Controllers
{
    public class GuestReservationsController : Controller
    {
        private readonly IGuestReservationRepository _guestReservationRepository;
		private readonly IGuestRepository _guestRepository;
        private readonly IReservationRepository _reservationRepository;
		public GuestReservationsController(IGuestReservationRepository guestReservationRepository, IGuestRepository guestRepository, IReservationRepository reservationRepository)
        {
            _guestReservationRepository = guestReservationRepository;
            _guestRepository = guestRepository;
            _reservationRepository = reservationRepository;

		}
        public async Task<IActionResult> Index()
        {
            var result = await _guestReservationRepository.GetGuestReservations();           
            await _guestRepository.GetGuests();
            await _reservationRepository.GetReservations();

			return View(result);
        }
        public async Task<IActionResult> Create()
        {
            var guests = await _guestRepository.GetGuests();
            ViewBag.GuestId = new SelectList(guests, "Id", "PersonalNumber");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(GuestReservation model)
        {
            await _guestReservationRepository.AddGuestReservation(model);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteConf(int id)
        {
            await _reservationRepository.DeleteReservation(id);
            var result = await _guestReservationRepository.GetSingleGuestReservation(id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _guestReservationRepository.DeleteGuestReservation(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await _guestReservationRepository.GetSingleGuestReservation(id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> UpdatePOST(GuestReservation model)
        {
            await _guestReservationRepository.UpdateGuestReservation(model);
            return RedirectToAction("Index");
        }
    }
}
