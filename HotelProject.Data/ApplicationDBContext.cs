using Microsoft.EntityFrameworkCore;

namespace HotelProject.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
        public static string ConnectionString { get; } = "Server=DESKTOP-5G4KLMO\\SQLEXPRESS;Database=DOITHotel_BCTFO;Trusted_Connection=True;TrustServerCertificate=true";
    }
}
