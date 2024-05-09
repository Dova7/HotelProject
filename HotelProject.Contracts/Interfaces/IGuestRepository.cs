using HotelProject.Contracts.Interfaces;
using HotelProject.Models;

namespace HotelProject.Repository.Interfaces
{
    public interface IGuestRepository : IBaseRepository<Guest>, IFullyUpdatable<Guest>, ISavable
    {
        
    }
}
