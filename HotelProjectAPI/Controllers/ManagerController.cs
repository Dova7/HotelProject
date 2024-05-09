using HotelProject.Contracts.ServiceInterfaces;
using HotelProject.Models;
using HotelProject.Models.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectAPI.Controllers
{
    [Route("api/managers")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Manager>>> GetAllManagers()
        {
            var result = await _managerService.GetAllManagers();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ManagerDTO>> AddNewManager([FromBody] ManagerDTO model)
        {
            await _managerService.AddNewManager(model);
            return Ok(model);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Manager>> DeleteManager([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id parameter");
            }
            await _managerService.DeleteManager(id);

            return NoContent();
        }
        [HttpPost("{id:int}")]
        public async Task<ActionResult<ManagerDTO>> UpdateManager([FromRoute] int id, [FromBody] ManagerDTO model)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id parameter");
            }
            model.Id = id;
            await _managerService.UpdateManager(model);

            return Ok(model);
        }
    }
}
