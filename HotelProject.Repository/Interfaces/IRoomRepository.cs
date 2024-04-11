using HotelProject.Models;

namespace HotelProject.Repository.Interfaces
{
    public interface IRoomRepository
    {
        public Task<List<Room>> GetRooms();
        public Task AddRoom(Room room);
        public Task UpdateRoom(Room room);
        public Task DeleteRoom(int id);

    }
}
