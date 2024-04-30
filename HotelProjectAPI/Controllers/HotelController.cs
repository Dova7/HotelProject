using HotelProject.Data;
using HotelProject.Models;
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

        public HotelController(IHotelRepository hotelRepository, ApplicationDBContext context)
        {
            _hotelRepository = hotelRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hotel>>> GetAllHotels()
        {
            var hotels = await _hotelRepository.GetAllAsync();

            if (hotels == null)
            {
                return NotFound("Hotels not found");
            }

            return Ok(hotels);
        }

        [HttpPost]
        public async Task<ActionResult<Hotel>> AddNewHotel([FromBody] Hotel model)
        {
            if (model != null)
            {
                await _hotelRepository.AddAsync(model);
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
        public async Task<ActionResult<Hotel>> UpdateHotel([FromRoute] int id, [FromBody] Hotel model)
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
