using AutoMapper;
using RideSharingPlatform.Microservices.RideManagement.Models;
using RideSharingPlatform.Microservices.RideManagement.Models.DTOs;

namespace RideSharingPlatform.Microservices.RideManagement.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() { 

            CreateMap<RideDTO,RideSchedule>().ReverseMap();
            CreateMap<Booking,BookingDTO>().ReverseMap();   
        
        }
    }
}
