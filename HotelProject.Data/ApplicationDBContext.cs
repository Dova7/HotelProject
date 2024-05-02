using HotelProject.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //hotel
            modelBuilder.SeedHotel();
            //manager
            modelBuilder.SeedManager();
            //room
            modelBuilder.SeedRoom();
            //guest
            modelBuilder.SeedGuest();
            //reservation
            modelBuilder.SeedReservation();
            //guestReservation
            modelBuilder.SeedGuestReservation();
        }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<GuestReservation> GuestReservations { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Room> Rooms { get; set; }


        //public static string ConnectionString { get; } = "Server=DESKTOP-5G4KLMO\\SQLEXPRESS;Database=DOITHotel_BCTFO;Trusted_Connection=True;TrustServerCertificate=true";
        public static string ConnectionString { get; } = "Server=DESKTOP-5G4KLMO\\SQLEXPRESS;Database=DOITHotel_BCTFO2;Trusted_Connection=True;TrustServerCertificate=true";
    }
}
