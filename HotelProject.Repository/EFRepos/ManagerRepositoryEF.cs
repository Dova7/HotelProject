using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Repository.EFRepos
{
    public class ManagerRepositoryEF : IManagerRepository
    {
        private readonly ApplicationDBContext _context;
        public ManagerRepositoryEF(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task AddManager(Manager manager)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }

            await _context.Managers.AddAsync(manager);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteManager(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }

            var entity = await _context.Managers.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new NullReferenceException("Entity not found");
            }

            _context.Managers.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Manager> GetManagerById(int id)
        {
            var entity = await _context.Managers.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new NullReferenceException("Entity not found");
            }

            return entity;

        }

        public async Task<List<Manager>> GetManagers()
        {
            var entities = await _context.Managers.Include(nameof(Hotel)).ToListAsync();

            if (entities == null)
            {
                throw new NullReferenceException("Entities not found");
            }

            return entities;

        }       
        public async Task UpdateManager(Manager manager)
        {
            if (manager == null || manager.Id <= 0)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }

            var entity = await _context.Managers.FirstOrDefaultAsync(x => x.Id == manager.Id);

            if (entity == null)
            {
                throw new NullReferenceException("Entity not found");
            }

            entity.FirstName = manager.FirstName;
            entity.SecondName = manager.SecondName;
            entity.HotelId = manager.HotelId;

            _context.Managers.Update(entity);
            await _context.SaveChangesAsync();

        }
    }
}
