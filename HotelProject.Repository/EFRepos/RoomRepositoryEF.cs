using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Repository.EFRepos
{
    public class RoomRepositoryEF : IRoomRepository
    {
        private readonly ApplicationDBContext _context;
        public RoomRepositoryEF(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task AddRoom(Room room)
        {
            if (room == null)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }

            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }

            var entity = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new NullReferenceException("Entity not found");
            }

            _context.Rooms.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Room>> GetRooms()
        {
            var entities = await _context.Rooms.ToListAsync();

            if (entities == null)
            {
                throw new NullReferenceException("Entities not found");
            }

            return entities;

        }
        public async Task UpdateRoom(Room room)
        {
            if (room == null || room.Id <= 0)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }

            var entity = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == room.Id);

            if (entity == null)
            {
                throw new NullReferenceException("Entity not found");
            }

            entity.RoomName = room.RoomName;
            entity.IsBooked = room.IsBooked;
            entity.HotelId = room.HotelId;
            entity.PriceGel = room.PriceGel;

            _context.Rooms.Update(entity);
            await _context.SaveChangesAsync();

        }
    }    
}
