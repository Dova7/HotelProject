using HotelProject.Contracts.Interfaces;
using HotelProject.Models;

namespace HotelProject.Repository.Interfaces
{
    public interface IRoomRepository : IBaseRepository<Room>, IFullyUpdatable<Room> 
    {
        
    }
}
