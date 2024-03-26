namespace HotelProject.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string? HotelName { get; set; }
        public double? Rating { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? PhysicalAddress { get; set; }
    }
}
