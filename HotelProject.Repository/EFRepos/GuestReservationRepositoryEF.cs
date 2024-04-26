using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Repository
{
    public class GuestReservationRepositoryEF : BaseRepository<GuestReservation>, IGuestReservationRepository
    {
        private readonly ApplicationDBContext _context;
        public GuestReservationRepositoryEF(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<GuestReservation> Update(GuestReservation entity)
        {
            var entityFromDb = await _context.GuestReservations.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (entityFromDb != null)
            {
                entityFromDb.ReservationId = entity.Id;
                entityFromDb.GuestId = entity.Id;
            }
            else
            {
                throw new ArgumentNullException();
            }

            _context.GuestReservations.Update(entityFromDb);
            return entityFromDb;
        }
    }
}
