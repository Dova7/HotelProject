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
        }
    }
}
