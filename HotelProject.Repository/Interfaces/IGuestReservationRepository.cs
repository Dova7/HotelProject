using HotelProject.Models;

namespace HotelProject.Repository.Interfaces
{
    public interface IGuestReservationRepository : IBaseRepository<GuestReservation>, IFullyUpdatable<GuestReservation>
    {

    }
}
    