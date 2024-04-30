using AutoMapper;
using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Models.DTOS;
using HotelProject.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectAPI.Controllers
{
    [Route("api/managers")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerRepository _mangerRepository;
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public ManagerController(IManagerRepository managerRepository, ApplicationDBContext context, IMapper mapper)
        {
            _mangerRepository = managerRepository;
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<Manager>>> GetAllManagers()
        {
            var raw = await _mangerRepository.GetAllAsync(includePropeties: "Hotel");

            List<ManagerDTO> managers = _mapper.Map<List<ManagerDTO>>(raw);
            if (managers == null)
            {
                return NotFound("Managers not found");
            }

            return Ok(managers);
        }

        [HttpPost]
        public async Task<ActionResult<ManagerDTO>> AddNewManager([FromBody] ManagerDTO model)
        {
            Manager newManager = _mapper.Map<Manager>(model);
            if (newManager != null)
            {
                await _mangerRepository.AddAsync(newManager);
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
        public async Task<ActionResult<ManagerDTO>> UpdateManager([FromRoute] int id, [FromBody] ManagerDTO model)
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
