using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Repository
{
    public class GuestRepositoryEF : BaseRepository<Guest>, IGuestRepository
    {
        private readonly ApplicationDBContext _context;
        public GuestRepositoryEF(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Guest> Update(Guest entity)
        {
            var entityFromDb = await _context.Guests.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (entityFromDb != null)
            {
                entityFromDb.FirstName = entity.FirstName;
                entityFromDb.LastName = entity.LastName;
                entityFromDb.PersonalNumber = entity.PersonalNumber;
                entityFromDb.PhoneNumber = entity.PhoneNumber;
            }
            else
            {
                throw new ArgumentNullException();
            }

            _context.Guests.Update(entityFromDb);
            return entityFromDb;
        }
        public async Task Save() => await _context.SaveChangesAsync();
    }
}
