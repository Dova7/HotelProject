using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Repository
{
    public class GuestRepositoryEF : IGuestRepository
    {
        private readonly ApplicationDBContext _context;

        public GuestRepositoryEF(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task AddGuest(Guest guest)
        {
            if (guest == null)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }

            await _context.Guests.AddAsync(guest);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGuest(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }

            var entity = await _context.Guests.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new NullReferenceException("Entity not found");
            }

            _context.Guests.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Guest>> GetGuests()
        {
            var entities = await _context.Guests.ToListAsync();

            if (entities == null)
            {
                throw new NullReferenceException("Entities not found");
            }

            return entities;
        }

        public async Task<Guest> GetSingleGuest(int id)
        {
            var entity = await _context.Guests.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new NullReferenceException("Entity not found");
            }

            return entity;
        }

        public async Task UpdateGuest(Guest guest)
        {
            if (guest == null || guest.Id <= 0)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }

            var entity = await _context.Guests.FirstOrDefaultAsync(x => x.Id == guest.Id);

            if (entity == null)
            {
                throw new NullReferenceException("Entity not found");
            }

            entity.FirstName = guest.FirstName;
            entity.LastName = guest.LastName;
            entity.PersonalNumber = guest.PersonalNumber;
            entity.PhoneNumber = guest.PhoneNumber;

            _context.Guests.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
