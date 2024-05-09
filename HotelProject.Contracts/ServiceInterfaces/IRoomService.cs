using HotelProject.Models.DTOS;

namespace HotelProject.Contracts.ServiceInterfaces
{
    public interface IRoomService
    {
        Task<List<RoomDTO>> GetAllRooms();
        Task AddNewRoom(RoomDTO model);
        Task DeleteRoom(int id);
        Task UpdateRoom(RoomDTO model);
    }
}
