using AutoMapper;
using HotelProject.Contracts.ServiceInterfaces;
using HotelProject.Models;
using HotelProject.Models.DTOS;
using HotelProject.Repository.Interfaces;

namespace HotelProject.Services.Implimentations
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public HotelService(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }
        public async Task<List<HotelDTO>> GetAllHotels()
        {
            var raw = await _hotelRepository.GetAllAsync(includePropeties: "Manager,Room");
            if (raw.Count == 0)
            {
                throw new ArgumentNullException("Hotels not found");
            }
            List<HotelDTO> hotels = _mapper.Map<List<HotelDTO>>(raw);
            return hotels;
        }
        public async Task AddNewHotel(HotelDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("invalid argument passed");
            }
            else
            {
                var result = _mapper.Map<Hotel>(model);
                await _hotelRepository.AddAsync(result);
                await _hotelRepository.Save();
            }
        }

        public async Task DeleteHotel(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid argument passed");
            }
            var result = await _hotelRepository.GetAsync(x => x.Id == id);
            if (result != null)
            {
                _hotelRepository.Remove(result);
            }
            else
            {
                throw new ArgumentNullException("Hotel not found");
            }
            await _hotelRepository.Save();
        }



        public async Task UpdateHotel(HotelDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }
            var result = _mapper.Map<Hotel>(model);
            await _hotelRepository.Update(result);
            await _hotelRepository.Save();
        }
    }
}
