using AutoMapper;
using RideSharingPlatform.Authentication.Models;
using RideSharingPlatform.Microservices.UserVerification.Models;
using RideSharingPlatform.Microservices.UserVerification.Models.DTOs;

namespace RideSharingPlatform.Microservices.UserVerification.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<NewApplicationDTO, UserApplication>().ReverseMap();
            CreateMap<NewApplicationDTO, DrivingLicense>().ReverseMap();
            CreateMap<UpdateApplicationDTO, UserApplication>().ReverseMap();
            CreateMap<AuthUser, UserApplication>().ReverseMap();
            CreateMap<showapplicationDTO, UserApplication>().ReverseMap();
            CreateMap<showapplicationDTO, DrivingLicense>().ReverseMap();

        }
    }
}
