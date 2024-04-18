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

            CreateMap<GuestReservationUpdateDTO, Guest>()
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
                .ReverseMap();
        }
    }
}
