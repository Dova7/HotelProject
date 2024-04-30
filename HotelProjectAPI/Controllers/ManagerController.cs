using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using HotelProject.Repository.MVCRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectAPI.Controllers
{
    [Route("api/managers")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerRepository _mangerRepository;
        private readonly ApplicationDBContext _context;
        public ManagerController(IManagerRepository managerRepository, ApplicationDBContext context)
        {
            _mangerRepository = managerRepository;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Manager>>> GetAllManagers()
        {
            var managers = await _mangerRepository.GetAllAsync();

            if (managers == null)
            {
                return NotFound("Managers not found");
            }

            return Ok(managers);
        }

        [HttpPost]
        public async Task<ActionResult<Manager>> AddNewManager([FromBody] Manager model)
        {
            if (model != null)
            {
                await _mangerRepository.AddAsync(model);
            }
            else
            {
                return BadRequest("Invalid parameter");
            }
            await _context.SaveChangesAsync();
            return Ok(model);
        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Manager>> DeleteManager([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id parameter");
            }

            var manager = await _mangerRepository.GetAsync(x => x.Id == id);

            if (manager != null)
            {
                _mangerRepository.Remove(manager);
            }
            else
            {
                return NotFound("Manager not found");

            }
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPost("{id:int}")]
        public async Task<ActionResult<Manager>> UpdateManager([FromRoute] int id, [FromBody] Manager model)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id parameter");
            }
            var manager = await _mangerRepository.GetAsync(x => x.Id == id);
            if (manager != null)
            {
                manager.FirstName = model.FirstName;
                manager.SecondName = model.SecondName;
                manager.HotelId = model.HotelId;

                await _mangerRepository.Update(manager);
            }
            else
            {
                return NotFound("Manager not found");

            }
            await _context.SaveChangesAsync();
            return Ok(model);
        }
    }
}
