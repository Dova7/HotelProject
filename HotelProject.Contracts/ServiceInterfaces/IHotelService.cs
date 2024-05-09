using HotelProject.Models.DTOS;

namespace HotelProject.Contracts.ServiceInterfaces
{
    public interface IHotelService
    {
        Task<List<HotelDTO>> GetAllHotels();
        Task AddNewHotel(HotelDTO model);
        Task DeleteHotel(int id);
        Task UpdateHotel(HotelDTO model);
    }
}
