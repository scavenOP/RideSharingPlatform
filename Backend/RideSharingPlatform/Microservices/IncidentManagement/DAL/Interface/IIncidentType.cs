using RideSharingPlatform.Microservices.IncidentManagement.Models;

namespace RideSharingPlatform.Microservices.IncidentManagement.DAL.Interface
{
    public interface IIncidentType
    {
        IEnumerable<IncidentTypes> GetIncidentTypes();

        IncidentTypes GetIncidentTypesById(int id);
    }
}
