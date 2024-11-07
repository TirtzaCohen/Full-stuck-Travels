using AutoMapper;
using BLL.Functions;
using DAL.Travels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class mapper:Profile
    {
        public mapper() 
        {
            CreateMap<TravelType, TravelTypeDTO>();
            CreateMap<TravelTypeDTO, TravelType>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Trip, TripDTO>()
                .ForMember(dest => dest.NameType, opt => opt.MapFrom(src => src.TypeCodeNavigation!.TypeName))
                .ForMember(dest => dest.Need_a_medic, opt => opt.MapFrom(src => 
                (src.BookingPlaces.FirstOrDefault(x => x.UserCodeNavigation != null && x.UserCodeNavigation.FirstAidCertificate == true) != null)? false : true));
            CreateMap<TripDTO, Trip>();

            CreateMap<BookingPlace, BookingPlaceDTO>()
                .ForMember(dest => dest.FullNameUser, opt => opt.MapFrom(src => src.UserCodeNavigation!.Name + " " + src.UserCodeNavigation.Family))
                .ForMember(dest => dest.TripDate, opt => opt.MapFrom(src => src.TripCodeNavigation!.Date))
                .ForMember(dest => dest.Destination, opt => opt.MapFrom(src => src.TripCodeNavigation!.TripDestination));
            CreateMap<BookingPlaceDTO, BookingPlace>(); 
        }
    }
}
