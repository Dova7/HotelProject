﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelProject.Models
{
    public class Guest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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

        public ICollection<GuestReservation> GuestReservations { get; set; } = null!;
    }
}
