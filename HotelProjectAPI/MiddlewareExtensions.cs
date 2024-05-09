using HotelProject.Contracts.ServiceInterfaces;
using HotelProject.Data;
using HotelProject.Repository;
using HotelProject.Repository.EFRepos;
using HotelProject.Repository.Interfaces;
using HotelProject.Services.Implimentations;
using HotelProject.Web;
using Microsoft.EntityFrameworkCore;

namespace HotelProjectAPI
{
    public static class MiddlewareExtensions
    {
        public static void AddDBContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerLocalConnection")));
        }
        public static void AddControllers(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
        }
        public static void AddAutoMapper(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(MappingProfile));
        }
        public static void AddScopedRepos(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IHotelRepository, HotelRepositoryEF>();
            builder.Services.AddScoped<IManagerRepository, ManagerRepositoryEF>();
            builder.Services.AddScoped<IRoomRepository, RoomRepositoryEF>();

            builder.Services.AddScoped<IGuestRepository, GuestRepositoryEF>();
            builder.Services.AddScoped<IReservationRepository, ReservationRepositoryEF>();
            builder.Services.AddScoped<IGuestReservationRepository, GuestReservationRepositoryEF>();
        }
        public static void AddScopedServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IHotelService, HotelService>();
            builder.Services.AddScoped<IManagerService, ManagerService>();
            builder.Services.AddScoped<IRoomService, RoomService>();
            builder.Services.AddScoped<IGuestReservationService, GuestReservationService>();
        }
    }
}
