using System.ComponentModel.DataAnnotations;

namespace HotelProject.Models.DTOS
{
	public class GuestReservationCreateDTO
	{
		[Required]
		[MaxLength(50)]
		public string FirstName { get; set; } = null!;

		[Required]
		[MaxLength(50)]
		public string LastName { get; set; } = null!;

		[Required]
		[StringLength(11)]
		public string PersonalNumber { get; set; } = null!;

		[Required]
		[MaxLength(25)]
		[Phone]
		public string PhoneNumber { get; set; } = null!;

		[Required]
		public DateTime CheckInDate { get; set; }

		[Required]
		public DateTime CheckOutDate { get; set; }

		public int GuestId { get; set; }
		public int ReservationId { get; set; }
	}
}
