namespace HotelProject.Models.DTOS
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string RoomName { get; set; } = null!;
        public bool? IsBooked { get; set; }
        public int? HotelId { get; set; }
        public double? PriceGel { get; set;}
    }
}
