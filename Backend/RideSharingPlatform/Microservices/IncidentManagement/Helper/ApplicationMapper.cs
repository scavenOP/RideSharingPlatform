using AutoMapper;
using RideSharingPlatform.Microservices.IncidentManagement.Models;
using RideSharingPlatform.Microservices.IncidentManagement.Models.DTO;

namespace RideSharingPlatform.Microservices.IncidentManagement.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() {
            CreateMap<Incident, IncidentDTOs>().ReverseMap();
        
        }
    }
}
