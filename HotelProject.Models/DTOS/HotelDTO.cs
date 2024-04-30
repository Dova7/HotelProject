using System.ComponentModel.DataAnnotations;

namespace HotelProject.Models.DTOS
{
    public class HotelDTO
    {
        public int Id { get; set; }
        public string HotelName { get; set; } = null!;
        [Range(0, 5)]
        public double Rating { get; set; }
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PhysicalAddress { get; set; } = null!;
/*        public int ManagerId { get; set; }

        public int RoomId { get; set; }*/

    }
}
