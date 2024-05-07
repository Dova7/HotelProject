using AutoMapper;
using HotelProject.Contracts.ServiceInterfaces;
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
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<ActionResult<List<HotelDTO>>> GetAllHotels()
        {
            var result = await _hotelService.GetAllHotels();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<HotelDTO>> AddNewHotel([FromBody] HotelDTO model)
        {
            await _hotelService.AddNewHotel(model);
            return Ok(model);
        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Hotel>> DeleteHotel([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id parameter");
            }
            await _hotelService.DeleteHotel(id);
            
            return NoContent();
        }
        [HttpPost("{id:int}")]
        public async Task<ActionResult<HotelDTO>> UpdateHotel([FromRoute] int id, [FromBody] HotelDTO model)
        {

            if (id <= 0)
            {
                return BadRequest("Invalid id parameter");
            }
            model.Id = id;
            await _hotelService.UpdateHotel(model);
            
            return Ok(model);
        }
    }
}
