using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Repository.EFRepos
{
    public class ManagerRepositoryEF : BaseRepository<Manager>, IManagerRepository
    {
        private readonly ApplicationDBContext _context;
        public ManagerRepositoryEF(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Manager> Update(Manager entity)
        {
            var entityFromDb = await _context.Managers.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (entityFromDb != null)
            {
                entityFromDb.FirstName = entity.FirstName;
                entityFromDb.SecondName = entity.SecondName;
                entityFromDb.HotelId = entity.HotelId;
            }
            else
            {
                throw new ArgumentNullException();
            }

            _context.Managers.Update(entityFromDb);
            return entityFromDb;
        }
        public async Task Save() => await _context.SaveChangesAsync();
    }
}
