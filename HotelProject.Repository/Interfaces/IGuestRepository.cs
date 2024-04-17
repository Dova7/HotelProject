using HotelProject.Models;

namespace HotelProject.Repository.Interfaces
{
    public interface IGuestRepository
    {
        public Task<List<Guest>> GetGuests();
        public Task<Guest> GetSingleGuest(int id);
        public Task<Guest> GetByPin(string personalNumber);
        public Task AddGuest(Guest guest);
        public Task UpdateGuest(Guest guest);
        public Task DeleteGuest(int id);
    }
}
