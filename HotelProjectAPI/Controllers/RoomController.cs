using AutoMapper;
using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Models.DTOS;
using HotelProject.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectAPI.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public RoomController(IRoomRepository roomRepository, ApplicationDBContext context, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<RoomDTO>>> GetAllRooms()
        {
            var raw = await _roomRepository.GetAllAsync(includePropeties: "Hotel");
            List<RoomDTO> rooms = _mapper.Map<List<RoomDTO>>(raw);

            if (rooms == null)
            {
                return NotFound("Rooms not found");
            }

            return Ok(rooms);
        }

        [HttpPost]
        public async Task<ActionResult<RoomDTO>> AddNewRoom([FromBody] RoomDTO model)
        {
            Room newRoom = _mapper.Map<Room>(model);
            if (newRoom != null)
            {
                await _roomRepository.AddAsync(newRoom);
            }
            else
            {
                return BadRequest("Invalid parameter");
            }
            await _context.SaveChangesAsync();
            return Ok(model);
        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Room>> DeleteRoom([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id parameter");
            }

            var room = await _roomRepository.GetAsync(x => x.Id == id);

            if (room != null)
            {
                _roomRepository.Remove(room);
            }
            else
            {
                return NotFound("Room not found");

            }
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPost("{id:int}")]
        public async Task<ActionResult<RoomDTO>> UpdateRoom([FromRoute] int id, [FromBody] RoomDTO model)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id parameter");
            }
            var room = await _roomRepository.GetAsync(x => x.Id == id);
            if (room != null)
            {
                room.RoomName = model.RoomName;
                room.IsBooked = model.IsBooked;
                room.HotelId = model.HotelId;
                room.PriceGel = model.PriceGel;

                await _roomRepository.Update(room);
            }
            else
            {
                return NotFound("Room not found");

            }
            await _context.SaveChangesAsync();
            return Ok(model);
        }
    }
}
