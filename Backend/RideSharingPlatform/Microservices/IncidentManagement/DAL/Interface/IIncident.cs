using RideSharingPlatform.Microservices.IncidentManagement.Models.DTO;
using RideSharingPlatform.Microservices.IncidentManagement.Models;

namespace RideSharingPlatform.Microservices.IncidentManagement.DAL.Interface
{
    public interface IIncident
    {
        string AddIncident(IncidentDTOs incidentDTOs);
        IEnumerable<Incident> GetAllPendingIncidents();
        //string CreateIncident(IncidentDTOs incidentDTO);
        int UpdateIncident(string id, string incidentReport);
        Incident GetIncidentTypesById(string id);
    }
}
