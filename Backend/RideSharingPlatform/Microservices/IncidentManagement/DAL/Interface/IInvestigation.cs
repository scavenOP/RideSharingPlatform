using RideSharingPlatform.Microservices.IncidentManagement.Models.DTO;

namespace RideSharingPlatform.Microservices.IncidentManagement.DAL.Interface
{
    public interface IInvestigation
    {
        int UpdateIncident(InvestigationDTO investigationDTO);
    }
}
