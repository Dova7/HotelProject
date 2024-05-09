using HotelProject.Models.DTOS;

namespace HotelProject.Contracts.ServiceInterfaces
{
    public interface IGuestReservationService
    {
        Task<List<GuestReservationDTO>> GetAllGuestReservation();
        Task AddNewGuestReservation(GuestReservationCreateDTO model);
        Task DeleteGuestReservation(int id);
        Task UpdateGuestReservation(GuestReservationUpdateDTO model);
    }
}