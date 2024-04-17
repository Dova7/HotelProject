using AutoMapper;
using HotelProject.Models;
using HotelProject.Models.DTOS;
using HotelProject.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.Web.Controllers
{
    public class GuestsController : Controller
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IGuestReservationRepository _guestReservationRepository;
        private readonly IMapper _mapper;
        public GuestsController(IGuestRepository guestRepository, IReservationRepository reservationRepository, IGuestReservationRepository guestReservationRepository, IMapper mapper)
        {
            _guestRepository = guestRepository;
            _reservationRepository = reservationRepository;
            _guestReservationRepository = guestReservationRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var raw = await _guestReservationRepository.GetGuestReservations();
			List<GuestReservationDTO> result = _mapper.Map<List<GuestReservationDTO>>(raw);
			return View(result);
		}


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(GuestReservationCreateDTO model)
        {
            Guest newGuest = _mapper.Map<Guest>(model);
            Reservation newReservation = _mapper.Map<Reservation>(model);

            await _guestRepository.AddGuest(newGuest);
            await _reservationRepository.AddReservation(newReservation);

            var newGuestFromDB = await _guestRepository.GetByPin(model.PersonalNumber);
			var newReservationFromDB = await _reservationRepository.GetByCheckInCheckOutDate(model.CheckInDate, model.CheckOutDate);

            model.GuestId = newGuestFromDB.Id;
            model.ReservationId = newReservationFromDB.Id;

            await _guestReservationRepository.AddGuestReservation(_mapper.Map<GuestReservation>(model));
			return RedirectToAction("Index");
        }


		public async Task<IActionResult> DeleteConf(int id)
		{
            var result = await _guestReservationRepository.GetSingleGuestReservation(id);
			return View(result);
		}


		[HttpPost]
        public async Task<IActionResult> Delete(int id, int guestId, int reservationId)
        {
            await _guestReservationRepository.DeleteGuestReservation(id);
            await _guestRepository.DeleteGuest(guestId);
            await _reservationRepository.DeleteReservation(reservationId);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            var result = await _guestRepository.GetSingleGuest(id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> Update(Guest model)
        {
            await _guestRepository.UpdateGuest(model);
            return RedirectToAction("Index");
        }
    }
}
