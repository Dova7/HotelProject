using System.ComponentModel.DataAnnotations;

namespace HotelProject.Models
{
    public class Manager
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public int? HotelId { get; set; }
        public Hotel Hotel { get; set; } = null!;
    }
}
