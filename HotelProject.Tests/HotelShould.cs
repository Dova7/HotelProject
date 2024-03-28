using HotelProject.Models;
using HotelProject.Repository;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;

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
        public void Return_All_Hotels_From_DB()
        {
            var result = _hotelRepository.GetHotels();
        }
        [Fact]
        public void Add_New_Hotel_To_DB()
        {
            Hotel newHotel = new Hotel()
            {
                HotelName = "Marriott",
                Rating = 4.3,
                Country = "Georgia",
                City = "Tbilisi",
                PhysicalAddress = "Rustaveli_Avenue"
            };

            _hotelRepository.AddHotel(newHotel);
        }
        [Fact]
        public void Update_Hotel_In_DB()
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
            _hotelRepository.UpdateHotel(updatedHotel);
        }
        [Fact]
        public void Delete_Hotel_In_DB()
        {
            _hotelRepository.DeleteHotel(2);
        }
    }
}
