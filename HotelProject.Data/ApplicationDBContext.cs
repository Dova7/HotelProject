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
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel()
                {
                    Id = 1,
                    HotelName = "Radisson Blu",
                    Rating = 4.5,
                    Country = "Georgia",
                    City = "Tbilisi",
                    PhysicalAddress = "Rose Revolution Square"
                },
                new Hotel()
                {
                    Id = 2,
                    HotelName = "The Biltmore",
                    Rating = 4,
                    Country = "Georgia",
                    City = "Tbilisi",
                    PhysicalAddress = "Shota Rustaveli Ave"
                },
                new Hotel()
                {
                    Id = 3,
                    HotelName = "Rooms Hotel",
                    Rating = 4.3,
                    Country = "Georgia",
                    City = "Tbilisi",
                    PhysicalAddress = "Merab Kostava Street"
                }
            );
            modelBuilder.Entity<Hotel>(entity =>
            {
                //Id
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

                //HotelName
                entity.Property(x => x.HotelName).IsRequired().HasMaxLength(50);

                //Rating
                entity.Property(x => x.Rating).HasDefaultValue(null);

                //Country
                entity.Property(x => x.Country).IsRequired().HasMaxLength(50);

                //City
                entity.Property(x => x.City).IsRequired().HasMaxLength(50);

                //PhysicalAddress
                entity.Property(x => x.PhysicalAddress).IsRequired().HasMaxLength(50);
            });

            //manager
            modelBuilder.Entity<Manager>().HasData(
                new Manager()
                {
                    Id = 1,
                    FirstName = "Giorgi",
                    SecondName = "Gujarelidze",
                    HotelId = 1
                },
                new Manager()
                {
                    Id = 2,
                    FirstName = "Saba",
                    SecondName = "Gujarelidze",
                    HotelId = 2
                },
                new Manager()
                {
                    Id = 3,
                    FirstName = "Irakli",
                    SecondName = "Gujarelidze",
                    HotelId = 3
                }
            );

            //room
            modelBuilder.Entity<Room>().HasData(
                new Room()
                {
                    Id=1,
                    RoomName= "Room 1",
                    IsBooked= true,
                    HotelId= 1,
                    PriceGel=125
                },
                new Room()
                {
                    Id = 2,
                    RoomName = "Room 2",
                    IsBooked = false,
                    HotelId = 1,
                    PriceGel = 79.99
                },
                new Room()
                {
                    Id = 3,
                    RoomName = "Room 1",
                    IsBooked = true,
                    HotelId = 2,
                    PriceGel = 119.99
                },
                new Room()
                {
                    Id = 4,
                    RoomName = "Room 2",
                    IsBooked = true,
                    HotelId = 2,
                    PriceGel = 150
                },
                new Room()
                {
                    Id = 5,
                    RoomName = "Room 1",
                    IsBooked = false,
                    HotelId = 3,
                    PriceGel = 122
                }
            );
            modelBuilder.Entity<Guest>().HasData(
                new Guest()
                {
                    Id = 1,
                    FirstName = "Nikoloz",
                    LastName = "Chkhartishvili",
                    PersonalNumber = "01024085083",
                    PhoneNumber = "555337681"
                },
                new Guest()
                {
                    Id = 2,
                    FirstName = "Khatia",
                    LastName = "Burduli",
                    PersonalNumber = "01024082203",
                    PhoneNumber = "579057747"
                },
                new Guest()
                {
                    Id = 3,
                    FirstName = "Erekle",
                    LastName = "Davitashvili",
                    PersonalNumber = "12345678947",
                    PhoneNumber = "571058998"
                },
                new Guest()
                {
                    Id = 4,
                    FirstName = "Dali",
                    LastName = "Goderdzishvili",
                    PersonalNumber = "87005633698",
                    PhoneNumber = "555887469"
                }
            );


            modelBuilder.Entity<Reservation>().HasData(
                new Reservation()
                {
                    Id = 1,
                    CheckInDate = DateTime.Now,
                    CheckOutDate = DateTime.Now.AddDays(10)
                },
                new Reservation()
                {
                    Id = 2,
                    CheckInDate = DateTime.Now,
                    CheckOutDate = DateTime.Now.AddMonths(1)
                },
                new Reservation()
                {
                    Id = 3,
                    CheckInDate = DateTime.Now,
                    CheckOutDate = DateTime.Now.AddDays(20)
                }
            );


            modelBuilder.Entity<GuestReservation>().HasData(
                    new GuestReservation()
                    {
                        Id = 1,
                        GuestId = 1,
                        ReservationId = 1
                    },
                    new GuestReservation()
                    {
                        Id = 2,
                        GuestId = 2,
                        ReservationId = 1
                    },
                    new GuestReservation()
                    {
                        Id = 3,
                        GuestId = 3,
                        ReservationId = 2
                    },
                    new GuestReservation()
                    {
                        Id = 4,
                        GuestId = 4,
                        ReservationId = 3
                    }
                );
            modelBuilder.Entity<Room>(entity =>
            {
                //id
                entity.HasKey( x => x.Id);
                entity.Property( x => x.Id).IsRequired().ValueGeneratedOnAdd();

                //room name
                entity.Property(x=>x.RoomName).IsRequired().HasMaxLength(50);

                //status
                entity.Property(x => x.IsBooked).IsRequired();

                //price
                entity.Property(x => x.PriceGel).IsRequired();

                //hotel
                entity.Property(x=> x.HotelId).IsRequired();
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                //id
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

                //first name
                entity.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
                //second name
                entity.Property(x => x.SecondName).IsRequired();
            });

            modelBuilder.Entity<Hotel>().HasOne(x => x.Manager).WithOne(x => x.Hotel).HasForeignKey<Manager>(x => x.HotelId);

            modelBuilder.Entity<Room>().HasOne(x => x.Hotel).WithMany(x=> x.Rooms).HasForeignKey(x => x.HotelId);
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
