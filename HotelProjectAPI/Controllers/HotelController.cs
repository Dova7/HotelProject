using AutoMapper;
using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Models.DTOS;
using HotelProject.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace HotelProjectAPI.Controllers
{
    [Route("api/hotels")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public HotelController(IHotelRepository hotelRepository, ApplicationDBContext context, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<HotelDTO>>> GetAllHotels()
        {
            var raw = await _hotelRepository.GetAllAsync(includePropeties: "Manager");
            List<HotelDTO> hotels = _mapper.Map<List<HotelDTO>>(raw);

            if (hotels == null)
            {
                return NotFound("Hotels not found");
            }

            return Ok(hotels);
        }

        [HttpPost]
        public async Task<ActionResult<HotelDTO>> AddNewHotel([FromBody] HotelDTO model)
        {
            Hotel newHotel = _mapper.Map<Hotel>(model);
            if (newHotel != null)
            {
                await _hotelRepository.AddAsync(newHotel);
            }
            else
            {
                return BadRequest("Invalid parameter");
            }
            await _context.SaveChangesAsync();
            return Ok(model);
        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Hotel>> DeleteHotel([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id parameter");
            }

            var hotel = await _hotelRepository.GetAsync(x => x.Id == id);

            if (hotel != null)
            {
                _hotelRepository.Remove(hotel);
            }
            else
            {
                return NotFound("Hotel not found");

            }
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPost("{id:int}")]
        public async Task<ActionResult<HotelDTO>> UpdateHotel([FromRoute] int id, [FromBody] HotelDTO model)
        {

            if (id <= 0)
            {
                return BadRequest("Invalid id parameter");
            }
            var hotel = await _hotelRepository.GetAsync(x => x.Id == id);

            if (hotel != null)
            {
                hotel.HotelName = model.HotelName;
                hotel.Rating = model.Rating;
                hotel.Country = model.Country;
                hotel.City = model.City;
                hotel.PhysicalAddress = model.PhysicalAddress;
                await _hotelRepository.Update(hotel);
            }
            else
            {
                return NotFound("Hotel not found");

            }
            await _context.SaveChangesAsync();
            return Ok(model);
        }
    }
}
