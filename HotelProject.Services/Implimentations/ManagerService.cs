using AutoMapper;
using HotelProject.Contracts.ServiceInterfaces;
using HotelProject.Models;
using HotelProject.Models.DTOS;
using HotelProject.Repository.Interfaces;

namespace HotelProject.Services.Implimentations
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _managerRepository;
        private readonly IMapper _mapper;

        public ManagerService(IManagerRepository managerRepository, IMapper mapper)
        {
            _managerRepository = managerRepository;
            _mapper = mapper;
        }
        public async Task AddNewManager(ManagerDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("invalid argument passed");
            }
            else
            {
                var result = _mapper.Map<Manager>(model);
                await _managerRepository.AddAsync(result);
                await _managerRepository.Save();
            }
        }

        public async Task DeleteManager(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid argument passed");
            }
            var result = await _managerRepository.GetAsync(x => x.Id == id);
            if (result != null)
            {
                _managerRepository.Remove(result);
            }
            else
            {
                throw new ArgumentNullException("Manager not found");
            }
            await _managerRepository.Save();
        }

        public async Task<List<ManagerDTO>> GetAllManagers()
        {
            var raw = await _managerRepository.GetAllAsync(includePropeties: "Hotel");
            if (raw.Count == 0)
            {
                throw new ArgumentNullException("Managers not found");
            }
            List<ManagerDTO> managers = _mapper.Map<List<ManagerDTO>>(raw);
            return managers;
        }

        public async Task UpdateManager(ManagerDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }
            var result = _mapper.Map<Manager>(model);
            await _managerRepository.Update(result);
            await _managerRepository.Save();
        }
    }
}
