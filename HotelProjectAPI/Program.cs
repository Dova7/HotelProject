using HotelProject.Repository;
using HotelProject.Repository.EFRepos;
using HotelProject.Repository.Interfaces;

namespace HotelProjectAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.AddAutoMapper();
            builder.AddDBContext();
            builder.AddControllers();

            builder.Services.AddScoped<IHotelRepository, HotelRepositoryEF>();
            builder.Services.AddScoped<IManagerRepository, ManagerRepositoryEF>();
            builder.Services.AddScoped<IRoomRepository, RoomRepositoryEF>();

            builder.Services.AddScoped<IGuestRepository, GuestRepositoryEF>();
            builder.Services.AddScoped<IReservationRepository, ReservationRepositoryEF>();
            builder.Services.AddScoped<IGuestReservationRepository, GuestReservationRepositoryEF>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
