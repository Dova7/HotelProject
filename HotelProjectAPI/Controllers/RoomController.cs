using HotelProject.Contracts.ServiceInterfaces;
using HotelProject.Models;
using HotelProject.Models.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectAPI.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpGet]
        public async Task<ActionResult<List<RoomDTO>>> GetAllRooms()
        {
            var result = await _roomService.GetAllRooms();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<RoomDTO>> AddNewRoom([FromBody] RoomDTO model)
        {
            await _roomService.AddNewRoom(model);
            return Ok(model);
        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Room>> DeleteRoom([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id parameter");
            }
            await _roomService.DeleteRoom(id);
            return NoContent();
        }
        [HttpPost("{id:int}")]
        public async Task<ActionResult<RoomDTO>> UpdateRoom([FromRoute] int id, [FromBody] RoomDTO model)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id parameter");
            }
            model.Id = id;
            await _roomService.UpdateRoom(model);
            return Ok(model);
        }
    }
}
