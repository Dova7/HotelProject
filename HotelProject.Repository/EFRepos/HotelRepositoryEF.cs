using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Repository.EFRepos
{
    public class HotelRepositoryEF : BaseRepository<Hotel>, IHotelRepository
    {
        private readonly ApplicationDBContext _context;
        public HotelRepositoryEF(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Hotel> Update(Hotel entity)
        {
            var entityFromDb = await _context.Hotels.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (entityFromDb != null)
            {
                entityFromDb.HotelName = entity.HotelName;
                entityFromDb.Rating = entity.Rating;
                entityFromDb.Country = entity.Country;
                entityFromDb.City = entity.City;
                entityFromDb.PhysicalAddress = entity.PhysicalAddress;
            }
            else
            {
                throw new ArgumentNullException();
            }

            _context.Hotels.Update(entityFromDb);
            return entityFromDb;
        }
    }
}
