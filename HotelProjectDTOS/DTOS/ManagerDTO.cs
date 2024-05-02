namespace HotelProject.Models.DTOS
{
    public class ManagerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public int HotelId { get; set; } 
    }
}
