using HotelProject.Models;
using HotelProject.Repository.Interfaces;

namespace HotelProject.Repository.EFRepos
{
    public class HotelRepositoryEF : IHotelRepository
    {
        public Task AddHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteHotel(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> GetHotelById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Hotel>> GetHotels()
        {
            throw new NotImplementedException();
        }

        public Task<List<Hotel>> GetHotelsWithoutManager()
        {
            throw new NotImplementedException();
        }

        public Task UpdateHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}
