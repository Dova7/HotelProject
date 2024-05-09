using HotelProject.Models.DTOS;

namespace HotelProject.Contracts.ServiceInterfaces
{
    public interface IManagerService
    {
        Task<List<ManagerDTO>> GetAllManagers();
        Task AddNewManager(ManagerDTO model);
        Task DeleteManager(int id);
        Task UpdateManager(ManagerDTO model);
    }
}
