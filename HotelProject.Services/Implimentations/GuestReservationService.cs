using AutoMapper;
using HotelProject.Contracts.ServiceInterfaces;
using HotelProject.Models;
using HotelProject.Models.DTOS;
using HotelProject.Repository.Interfaces;

namespace HotelProject.Services.Implimentations
{
    public class GuestReservationService : IGuestReservationService
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IGuestReservationRepository _guestReservationRepository;
        private readonly IMapper _mapper;
        public GuestReservationService(IGuestReservationRepository guestReservationRepository, IMapper mapper, IGuestRepository guestRepository, IReservationRepository reservationRepository)
        {
            _guestRepository = guestRepository;
            _reservationRepository = reservationRepository;
            _guestReservationRepository = guestReservationRepository;
            _mapper = mapper;
        }

        public async Task AddNewGuestReservation(GuestReservationCreateDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("invalid argument passed");
            }
            else
            {
                Guest newGuest = _mapper.Map<Guest>(model);
                Reservation newReservation = _mapper.Map<Reservation>(model);
                if (newGuest != null && newReservation != null)
                {
                    await _guestRepository.AddAsync(newGuest);
                    await _reservationRepository.AddAsync(newReservation);
                }
                await _guestRepository.Save();
                await _reservationRepository.Save();
            }
            var newGuestFromDB = await _guestRepository.GetAsync(x => x.PersonalNumber == model.PersonalNumber);
            var newReservationFromDB = await _reservationRepository.GetAsync(x => x.CheckInDate == model.CheckInDate && x.CheckOutDate == model.CheckOutDate);
            if (newGuestFromDB != null && newReservationFromDB != null)
            {
                model.GuestId = newGuestFromDB.Id;
                model.ReservationId = newReservationFromDB.Id;
            }
            await _guestReservationRepository.AddAsync(_mapper.Map<GuestReservation>(model));
            await _guestReservationRepository.Save();
        }

        public async Task DeleteGuestReservation(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid argument passed");
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

                    await _guestRepository.Save();
                    await _reservationRepository.Save();
                }
                else
                {
                    throw new NullReferenceException("Guest Reservation not found");
                }
            }
            await _guestReservationRepository.Save();
        }

        public async Task<List<GuestReservationDTO>> GetAllGuestReservation()
        {
            var raw = await _guestReservationRepository.GetAllAsync(includePropeties: "Guest,Reservation");           
            if (raw == null)
            {
                throw new NullReferenceException("entities not found");
            }
            List<GuestReservationDTO> result = _mapper.Map<List<GuestReservationDTO>>(raw);
            return result;

        }

        public async Task UpdateGuestReservation(GuestReservationUpdateDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Invalid model passed");
            }

            var updateGuest = _mapper.Map<Guest>(model);
            var updateReservation = _mapper.Map<Reservation>(model);

            if (updateGuest != null && updateReservation != null)
            {
                await _guestRepository.Update(updateGuest);
                await _reservationRepository.Update(updateReservation);

                await _guestRepository.Save();
                await _reservationRepository.Save();
            }

            var updatedGuestFromDB = await _guestRepository.GetAsync(x => x.PersonalNumber == model.PersonalNumber);
            var updatedReservationFromDB = await _reservationRepository.GetAsync(x => x.CheckInDate == model.CheckInDate && x.CheckOutDate == model.CheckOutDate);
            
            if (updatedGuestFromDB != null && updatedReservationFromDB != null)
            {
                model.GuestId = updatedGuestFromDB.Id;
                model.ReservationId = updatedReservationFromDB.Id;
            }

            await _guestReservationRepository.Update(_mapper.Map<GuestReservation>(model));
            await _guestReservationRepository.Save();
        }
    }
}
