using System.ComponentModel.DataAnnotations;

namespace HotelProject.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string? HotelName { get; set; }
        [Range(0, 5)]
        public double? Rating { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? PhysicalAddress { get; set; }
        public Manager? Manager { get; set; }
        public ICollection<Room>? Room { get; set; }
    }
}
