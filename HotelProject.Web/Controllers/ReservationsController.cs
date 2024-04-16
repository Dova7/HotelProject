using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IReservationRepository _reservationRepository;
        public ReservationsController(IReservationRepository RrservationRepository)
        {
            _reservationRepository = RrservationRepository;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _reservationRepository.GetReservations();

            return View(result);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Reservation model)
        {
            await _reservationRepository.AddReservation(model);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var result = await _reservationRepository.GetSingleReservation(id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> DeletePOST(int id)
        {
            await _reservationRepository.DeleteReservation(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await _reservationRepository.GetSingleReservation(id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> UpdatePOST(Reservation model)
        {
            await _reservationRepository.UpdateReservation(model);
            return RedirectToAction("Index");
        }
    }
}
