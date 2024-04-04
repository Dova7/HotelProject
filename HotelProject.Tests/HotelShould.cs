using HotelProject.Models;
using HotelProject.Repository;

namespace HotelProject.Tests
{
    public class HotelShould
    {
        private readonly HotelRepository _hotelRepository;
        public HotelShould()
        {
            _hotelRepository = new();
        }
        [Fact]
        public async Task Return_All_Hotels_From_DB()
        {
            var result = await _hotelRepository.GetHotels();
        }
        [Fact]
        public async Task Return_All_Hotels_Without_Manager_From_DB()
        {
            var result = await _hotelRepository.GetHotelsWithoutManager();
        }
        [Fact]
        public async Task Add_New_Hotel_To_DB()
        {
            Hotel newHotel = new Hotel()
            {
                HotelName = "Marriott",
                Rating = 4.3,
                Country = "Georgia",
                City = "Tbilisi",
                PhysicalAddress = "Rustaveli_Avenue"
            };

            await _hotelRepository.AddHotel(newHotel);
        }
        [Fact]
        public async Task Update_Hotel_In_DB()
        {
            Hotel updatedHotel = new Hotel()
            {
                Id = 2,
                HotelName = "Marriott",
                Rating = 4.3,
                Country = "Georgia",
                City = "Tbilisi",
                PhysicalAddress = "Rustaveli_Avenue"
            };
            await _hotelRepository.UpdateHotel(updatedHotel);
        }
        [Fact]
        public async Task Delete_Hotel_In_DB()
        {
            await _hotelRepository.DeleteHotel(4);
        }
        [Fact]
        public async Task Get_Single_Hotel_By_Id()
        {
            await _hotelRepository.GetHotelById(2);
        }
    }
}
