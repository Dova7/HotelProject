using AutoMapper;
using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Models.DTOS;
using HotelProject.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectAPI.Controllers
{
    [Route("api/guests")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IGuestReservationRepository _guestReservationRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDBContext _context;

        public GuestController(IGuestRepository guestRepository, IReservationRepository reservationRepository, ApplicationDBContext context, IMapper mapper, IGuestReservationRepository guestReservationRepository)
        {
            _context = context;
            _mapper = mapper;
            _guestRepository = guestRepository;
            _reservationRepository = reservationRepository;
            _guestReservationRepository = guestReservationRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<GuestReservationDTO>>> GetAllGuestReservations()
        {
            var raw = await _guestReservationRepository.GetAllAsync(includePropeties: "Guest,Reservation");
            List<GuestReservationDTO> result = _mapper.Map<List<GuestReservationDTO>>(raw);

            if (result == null)
            {
                return NotFound("entities not found");
            }

            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<GuestReservationCreateDTO>> AddNewGuestReservation([FromBody] GuestReservationCreateDTO model)
        {
            Guest newGuest = _mapper.Map<Guest>(model);
            Reservation newReservation = _mapper.Map<Reservation>(model);

            if (newGuest != null && newReservation != null)
            {
                await _guestRepository.AddAsync(newGuest);
                await _reservationRepository.AddAsync(newReservation);
            }
            else
            {
                return BadRequest("Invalid parameter");
            }
            await _context.SaveChangesAsync();

            var newGuestFromDB = await _guestRepository.GetAsync(x => x.PersonalNumber == model.PersonalNumber);
            var newReservationFromDB = await _reservationRepository.GetAsync(x => x.CheckInDate == model.CheckInDate && x.CheckOutDate == model.CheckOutDate);

            if (newGuestFromDB != null && newReservationFromDB != null)
            {
                model.GuestId = newGuestFromDB.Id;
                model.ReservationId = newReservationFromDB.Id;
            }
            await _guestReservationRepository.AddAsync(_mapper.Map<GuestReservation>(model));
            await _context.SaveChangesAsync();

            return Ok(model);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<GuestReservation>> DeleteGuestReservation([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id parameter");
            }

            var guestReservation = await _guestReservationRepository.GetAsync(x => x.Id == id);

            if (guestReservation != null)
            {
                var guest = await _guestRepository.GetAsync(x => x.Id == guestReservation.GuestId);
                var reservation = await _reservationRepository.GetAsync(x => x.Id == guestReservation.ReservationId);

                _guestReservationRepository.Remove(guestReservation);

                if (reservation != null && guest != null)
                {
                    _reservationRepository.Remove(reservation);
                    _guestRepository.Remove(guest);
                }
            }
            else
            {
                return NotFound("Guest Reservation not found");
            }
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPost("{id:int}")]
        public async Task<ActionResult<GuestReservationUpdateDTO>> UpdateGuestReservation([FromRoute] int id, [FromBody] GuestReservationUpdateDTO model)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id parameter");
            }
            var raw = await _guestReservationRepository.GetAsync(x => x.Id == id, includePropeties: "Guest,Reservation");
            var result = _mapper.Map<GuestReservationUpdateDTO>(raw);
            if (result != null)
            {
                Guest? guest = await _guestRepository.GetAsync(x => x.Id == result.GuestId);
                Reservation? reservation = await _reservationRepository.GetAsync(x => x.Id == result.ReservationId);

                if (guest != null && reservation != null)
                {
                    guest.FirstName = model.FirstName;
                    guest.LastName = model.LastName;
                    guest.PersonalNumber = model.PersonalNumber;
                    guest.PhoneNumber = model.PhoneNumber;
                    reservation.CheckInDate = model.CheckInDate;
                    reservation.CheckOutDate = model.CheckOutDate;

                    await _guestRepository.Update(guest);
                    await _reservationRepository.Update(reservation);
                }
            }
            else
            {
                return NotFound("Entities not found");
            }
            var updatedGuestFromDB = await _guestRepository.GetAsync(x => x.PersonalNumber == model.PersonalNumber);
            var updatedReservationFromDB = await _reservationRepository.GetAsync(x => x.CheckInDate == model.CheckInDate && x.CheckOutDate == model.CheckOutDate);

            if (updatedGuestFromDB != null && updatedReservationFromDB != null)
            {
                model.GuestId = updatedGuestFromDB.Id;
                model.ReservationId = updatedReservationFromDB.Id;
                model.Id = result.Id;
            }
            await _context.SaveChangesAsync();
            await _guestReservationRepository.Update(_mapper.Map<GuestReservation>(model));

            return Ok(model);
        }
    }
}
