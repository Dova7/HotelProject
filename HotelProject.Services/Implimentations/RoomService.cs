using AutoMapper;
using HotelProject.Contracts.ServiceInterfaces;
using HotelProject.Models;
using HotelProject.Models.DTOS;
using HotelProject.Repository.Interfaces;

namespace HotelProject.Services.Implimentations
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        public RoomService(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }
        public async Task AddNewRoom(RoomDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("invalid argument passed");
            }
            else
            {
                var result = _mapper.Map<Room>(model);
                await _roomRepository.AddAsync(result);
                await _roomRepository.Save();
            }
        }

        public async Task DeleteRoom(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid argument passed");
            }
            var result = await _roomRepository.GetAsync(x => x.Id == id);
            if (result != null)
            {
                _roomRepository.Remove(result);
            }
            else
            {
                throw new ArgumentNullException("Room not found");
            }
            await _roomRepository.Save();
        }

        public async Task<List<RoomDTO>> GetAllRooms()
        {
            var raw = await _roomRepository.GetAllAsync(includePropeties: "Hotel");
            if (raw.Count == 0)
            {
                throw new ArgumentNullException("Rooms not found");
            }
            List<RoomDTO> rooms = _mapper.Map<List<RoomDTO>>(raw);
            return rooms;
        }

        public async Task UpdateRoom(RoomDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }
            var result = _mapper.Map<Room>(model);
            await _roomRepository.Update(result);
            await _roomRepository.Save();
        }
    }
}
