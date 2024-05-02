using AutoMapper;
using HotelProject.Models;
using HotelProject.Models.DTOS;

namespace HotelProject.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GuestReservation, GuestReservationDTO>()
                .ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))
                .ForMember(dest => dest.GuestId, options => options.MapFrom(src => src.GuestId))
                .ForMember(dest => dest.FirstName, options => options.MapFrom(src => src.Guest.FirstName))
                .ForMember(dest => dest.LastName, options => options.MapFrom(src => src.Guest.LastName))
                .ForMember(dest => dest.PersonalNumber, options => options.MapFrom(src => src.Guest.PersonalNumber))
                .ForMember(dest => dest.PhoneNumber, options => options.MapFrom(src => src.Guest.PhoneNumber))
                .ForMember(dest => dest.ReservationId, options => options.MapFrom(src => src.ReservationId))
                .ForMember(dest => dest.CheckInDate, options => options.MapFrom(src => src.Reservation.CheckInDate))
                .ForMember(dest => dest.CheckOutDate, options => options.MapFrom(src => src.Reservation.CheckOutDate))
                .ReverseMap();

            CreateMap<Hotel, HotelDTO>()
                .ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))
                .ForMember(dest => dest.HotelName, options => options.MapFrom(src => src.HotelName))
                .ForMember(dest => dest.Rating, options => options.MapFrom(src => src.Rating))
                .ForMember(dest => dest.Country, options => options.MapFrom(src => src.Country))
                .ForMember(dest => dest.City, options => options.MapFrom(src => src.City))
                .ForMember(dest => dest.PhysicalAddress, options => options.MapFrom(src => src.PhysicalAddress))
                .ReverseMap();

            CreateMap<Manager, ManagerDTO>()
                .ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, options => options.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.SecondName, options => options.MapFrom(src => src.SecondName))
                .ForMember(dest => dest.SecondName, options => options.MapFrom(src => src.SecondName))
                .ReverseMap();

            CreateMap<Room, RoomDTO>()
               .ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))
               .ForMember(dest => dest.RoomName, options => options.MapFrom(src => src.RoomName))
               .ForMember(dest => dest.IsBooked, options => options.MapFrom(src => src.IsBooked))
               .ForMember(dest => dest.PriceGel, options => options.MapFrom(src => src.PriceGel))
               .ForMember(dest => dest.HotelId, options => options.MapFrom(src => src.HotelId))
               .ReverseMap();

            CreateMap<GuestReservationCreateDTO, GuestReservation>().ReverseMap();
            CreateMap<GuestReservationCreateDTO, Guest>().ReverseMap();
            CreateMap<GuestReservationCreateDTO, Reservation>().ReverseMap();

            CreateMap<GuestReservation, GuestReservationUpdateDTO>()
                .ForMember(dest => dest.GuestId, options => options.MapFrom(src => src.GuestId))
                .ForMember(dest => dest.FirstName, options => options.MapFrom(src => src.Guest.FirstName))
                .ForMember(dest => dest.LastName, options => options.MapFrom(src => src.Guest.LastName))
                .ForMember(dest => dest.PersonalNumber, options => options.MapFrom(src => src.Guest.PersonalNumber))
                .ForMember(dest => dest.PhoneNumber, options => options.MapFrom(src => src.Guest.PhoneNumber))
                .ForMember(dest => dest.ReservationId, options => options.MapFrom(src => src.ReservationId))
                .ForMember(dest => dest.CheckInDate, options => options.MapFrom(src => src.Reservation.CheckInDate))
                .ForMember(dest => dest.CheckOutDate, options => options.MapFrom(src => src.Reservation.CheckOutDate))
                .ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))
                .ReverseMap();

            /*CreateMap<GuestReservationUpdateDTO, Guest>()
                .ForMember(dest => dest.Id, options => options.MapFrom(src => src.GuestId))
                .ForMember(dest => dest.FirstName, options => options.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, options => options.MapFrom(src => src.LastName))
                .ForMember(dest => dest.PersonalNumber, options => options.MapFrom(src => src.PersonalNumber))
                .ForMember(dest => dest.PhoneNumber, options => options.MapFrom(src => src.PhoneNumber))
                .ReverseMap();

            CreateMap<GuestReservationUpdateDTO, Reservation>()
                .ForMember(dest => dest.Id, options => options.MapFrom(src => src.ReservationId))
                .ForMember(dest => dest.CheckInDate, options => options.MapFrom(src => src.CheckInDate))
                .ForMember(dest => dest.CheckOutDate, options => options.MapFrom(src => src.CheckOutDate))
                .ReverseMap();*/
        }
    }
}
