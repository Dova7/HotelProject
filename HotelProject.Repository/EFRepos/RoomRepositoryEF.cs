using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Repository.EFRepos
{
    public class RoomRepositoryEF : BaseRepository<Room>, IRoomRepository
    {
        private readonly ApplicationDBContext _context;
        public RoomRepositoryEF(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Room> Update(Room entity)
        {
            var entityFromDb = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (entityFromDb != null)
            {
                entityFromDb.RoomName = entity.RoomName;
                entityFromDb.IsBooked = entity.IsBooked;
                entityFromDb.HotelId = entity.HotelId;
                entityFromDb.PriceGel = entity.PriceGel;
            }
            else
            {
                throw new ArgumentNullException();
            }

            _context.Rooms.Update(entityFromDb);
            return entityFromDb;
        }
    }    
}
