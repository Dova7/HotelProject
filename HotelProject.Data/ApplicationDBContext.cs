using HotelProject.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Hotel> Hotels { get; set; }
        //public static string ConnectionString { get; } = "Server=DESKTOP-5G4KLMO\\SQLEXPRESS;Database=DOITHotel_BCTFO;Trusted_Connection=True;TrustServerCertificate=true";
        public static string ConnectionString { get; } = "Server=DESKTOP-5G4KLMO\\SQLEXPRESS;Database=DOITHotel_BCTFO2;Trusted_Connection=True;TrustServerCertificate=true";
    }
}
