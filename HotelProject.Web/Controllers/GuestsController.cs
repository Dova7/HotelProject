using AutoMapper;
using HotelProject.Data;
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
        private readonly ApplicationDBContext _context;
        public GuestsController(IGuestRepository guestRepository, IReservationRepository reservationRepository, IGuestReservationRepository guestReservationRepository, IMapper mapper, ApplicationDBContext context)
        {
            _guestRepository = guestRepository;
            _reservationRepository = reservationRepository;
            _guestReservationRepository = guestReservationRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var raw = await _guestReservationRepository.GetAllAsync();
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

            await _guestRepository.AddAsync(newGuest);
            await _reservationRepository.AddAsync(newReservation);

            var newGuestFromDB = await _guestRepository.GetAsync(x => x.PersonalNumber == model.PersonalNumber);
            var newReservationFromDB = await _reservationRepository.GetAsync(x => x.CheckInDate == model.CheckInDate && x.CheckOutDate == model.CheckOutDate);

            if (newGuestFromDB != null && newReservationFromDB != null)
            {
                model.GuestId = newGuestFromDB.Id;
                model.ReservationId = newReservationFromDB.Id;
            }

            await _guestReservationRepository.AddAsync(_mapper.Map<GuestReservation>(model));
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteConf(int id)
        {
            var result = await _guestReservationRepository.GetAsync(x => x.Id == id);
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id, int guestId, int reservationId)
        {
            var guestReservation = await _guestReservationRepository.GetAsync(x => x.Id == id);
            if (guestReservation != null)
            {
                _guestReservationRepository.Remove(guestReservation);
            }
            var guest = await _guestRepository.GetAsync(x => x.Id == guestId);
            if (guest != null)
            {
                _guestRepository.Remove(guest);
            }
            var reservation = await _reservationRepository.GetAsync(x => x.Id == reservationId);
            if (reservation != null)
            {
                _reservationRepository.Remove(reservation);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            var raw = await _guestReservationRepository.GetAsync(x=>x.Id == id);
            var result = _mapper.Map<GuestReservationUpdateDTO>(raw);

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(GuestReservationUpdateDTO model)
        {
            Guest updatedGuest = _mapper.Map<Guest>(model);
            Reservation updatedReservation = _mapper.Map<Reservation>(model);

            await _guestRepository.Update(updatedGuest);
            await _reservationRepository.Update(updatedReservation);

            var updatedGuestFromDB = await _guestRepository.GetAsync(x=>x.PersonalNumber == model.PersonalNumber);
            var updatedReservationFromDB = await _reservationRepository.GetAsync(x => x.CheckInDate == model.CheckInDate && x.CheckOutDate == model.CheckOutDate);

            if(updatedGuestFromDB != null && updatedReservationFromDB != null)
            {
                model.GuestId = updatedGuestFromDB.Id;
                model.ReservationId = updatedReservationFromDB.Id;
            }            

            await _guestReservationRepository.Update(_mapper.Map<GuestReservation>(model));
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
