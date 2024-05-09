using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Repository
{
    public class ReservationRepositoryEF : BaseRepository<Reservation>, IReservationRepository
    {
        private readonly ApplicationDBContext _context;
        public ReservationRepositoryEF(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Reservation> Update(Reservation entity)
        {
            var entityFromDb = await _context.Reservations.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (entityFromDb != null)
            {
                entityFromDb.CheckInDate = entity.CheckInDate;
                entityFromDb.CheckOutDate = entity.CheckOutDate;
            }
            else
            {
                throw new ArgumentNullException();
            }

            _context.Reservations.Update(entityFromDb);
            return entityFromDb;
        }
        public async Task Save() => await _context.SaveChangesAsync();
    }
}