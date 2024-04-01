namespace HotelProject.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string? RoomName { get; set; }
        public bool? IsBooked { get; set; }
        public int? HotelId { get; set; }
        public double? PriceGel { get; set; }
    }
}
