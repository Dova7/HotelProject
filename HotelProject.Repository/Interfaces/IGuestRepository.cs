using HotelProject.Models;

namespace HotelProject.Repository.Interfaces
{
    public interface IGuestRepository
    {
        Task<List<Guest>> GetGuests();
        public Task<Guest> GetSingleGuest(int id);
        public Task AddGuest(Guest guest);
        public Task UpdateGuest(Guest guest);
        public Task DeleteGuest(int id);
    }
}
