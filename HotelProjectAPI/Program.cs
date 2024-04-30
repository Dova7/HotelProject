using HotelProject.Data;
using HotelProject.Repository.EFRepos;
using HotelProject.Repository.Interfaces;
using HotelProject.Web;
using Microsoft.EntityFrameworkCore;

namespace HotelProjectAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerLocalConnection")));
            builder.Services.AddScoped<IHotelRepository, HotelRepositoryEF>();
            builder.Services.AddScoped<IManagerRepository, ManagerRepositoryEF>();
            builder.Services.AddScoped<IRoomRepository, RoomRepositoryEF>();


            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
