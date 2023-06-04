using RideSharingPlatform.Microservices.IncidentManagement.Models.DTO;
using RideSharingPlatform.Microservices.IncidentManagement.Models;

namespace RideSharingPlatform.Microservices.IncidentManagement.DAL.Interface
{
    public interface IIncident
    {
        //int InsertIncident(Incident incident);
        //Task<Incident> GetAsyc(int id);
        //int AddIncident(Incident incident);
        string AddIncident(IncidentDTOs incidentDTOs);
        IEnumerable<Incident> GetAllPendingIncidents();
        //string CreateIncident(IncidentDTOs incidentDTO);
        //int UpdateIncident(string incidentID);
        Incident GetIncidentTypesById(string id);
    }
}
