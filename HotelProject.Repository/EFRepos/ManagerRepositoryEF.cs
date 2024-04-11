using HotelProject.Models;
using HotelProject.Repository.Interfaces;

namespace HotelProject.Repository.EFRepos
{
    public class ManagerRepositoryEF : IManagerRepository
    {
        public Task AddManager(Manager manager)
        {
            throw new NotImplementedException();
        }

        public Task DeleteManager(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Manager> GetManagerById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Manager>> GetManagers()
        {
            throw new NotImplementedException();
        }

        public Task UpdateManager(Manager manager)
        {
            throw new NotImplementedException();
        }
    }
}
