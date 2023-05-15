using AutoMapper;
using RideSharingPlatform.Microservices.VehicleManagement.Models;
using RideSharingPlatform.Microservices.VehicleManagement.Models.DTOs;

namespace RideSharingPlatform.Microservices.VehicleManagement.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<RegisterVehicleDTO,Vehicle>().ReverseMap();
            CreateMap<RegisterVehicleDTO, VehicleDetail>().ReverseMap();
            CreateMap<VehicleDTO, VehicleDetail>().ReverseMap();
            CreateMap<VehicleDTO, Vehicle>().ReverseMap();


        }
    }
}
