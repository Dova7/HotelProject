using AutoMapper;
using HotelProject.Contracts.ServiceInterfaces;
using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Models.DTOS;
using HotelProject.Repository.Interfaces;
using HotelProject.Services.Implimentations;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectAPI.Controllers
{
    [Route("api/guests")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestReservationService _guestReservationService;

        public GuestController(IGuestReservationService guestReservationService)
        {
            _guestReservationService = guestReservationService;            
        }
        [HttpGet]
        public async Task<ActionResult<List<GuestReservationDTO>>> GetAllGuestReservations()
        {
            var result = await _guestReservationService.GetAllGuestReservation();

            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<GuestReservationCreateDTO>> AddNewGuestReservation([FromBody] GuestReservationCreateDTO model)
        {
            await _guestReservationService.AddNewGuestReservation(model);
            return Ok(model);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<GuestReservation>> DeleteGuestReservation([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id parameter");
            }
            await _guestReservationService.DeleteGuestReservation(id);
            
            return NoContent();
        }
        [HttpPost("{id:int}")]
        public async Task<ActionResult<GuestReservationUpdateDTO>> UpdateGuestReservation([FromRoute] int id, [FromBody] GuestReservationUpdateDTO model)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id parameter");
            }
            model.Id = id;
            await _guestReservationService.UpdateGuestReservation(model);

            return Ok(model);
        }
    }
}
