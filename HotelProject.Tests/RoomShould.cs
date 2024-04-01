using HotelProject.Models;
using HotelProject.Repository;

namespace HotelProject.Tests
{
    public class RoomShould
    {
        private readonly RoomRepository _roomRepository;
        public RoomShould()
        {
            _roomRepository = new();
        }
        [Fact]
        public async Task Return_All_Rooms_From_DB()
        {
            var result = await _roomRepository.GetRooms();
        }
        [Fact]
        public async Task Add_New_Room_To_DB()
        {
            Room newRoom = new Room()
            {
                RoomName = "Room 5",
                IsBooked = false,
                HotelId = 1,
                PriceGel = 199
            };

            await _roomRepository.AddRoom(newRoom);
        }
        [Fact]
        public async Task Update_Room_In_DB()
        {
            Room updatedRoom = new Room()
            {
                Id = 1,
                RoomName = "Room 5",
                IsBooked = false,
                HotelId = 1,
                PriceGel = 199
            };
            await _roomRepository.UpdateRoom(updatedRoom);
        }
        [Fact]
        public async Task Delete_Room_In_DB()
        {
            await _roomRepository.DeleteRoom(4);
        }
    }
}
