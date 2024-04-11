using HotelProject.Data;
using HotelProject.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HotelProject.Repository.Interfaces
{
    public interface IHotelRepository
    {
        public Task<List<Hotel>> GetHotels();
        public Task AddHotel(Hotel hotel);
        public Task UpdateHotel(Hotel hotel);
        public Task DeleteHotel(int id);
        public Task<List<Hotel>> GetHotelsWithoutManager();
        public Task<Hotel> GetHotelById(int id);
        
    }
}
