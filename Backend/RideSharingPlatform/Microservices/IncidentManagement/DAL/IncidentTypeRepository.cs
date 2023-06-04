using RideSharingPlatform.Context;
using RideSharingPlatform.Microservices.IncidentManagement.DAL.Interface;
using RideSharingPlatform.Microservices.IncidentManagement.Models;

namespace RideSharingPlatform.Microservices.IncidentManagement.DAL
{
    public class IncidentTypeRepository : IIncidentType
    {
        private readonly RideDbContext iDPDbContext;

        public IncidentTypeRepository(RideDbContext iDPDbContext)
        {
            this.iDPDbContext = iDPDbContext;
        }

        public IEnumerable<IncidentTypes> GetIncidentTypes()
        {
            return iDPDbContext.IncidentTypes.ToList();

        }

        public IncidentTypes GetIncidentTypesById(int id)
        {
            return iDPDbContext.IncidentTypes.FirstOrDefault(x => x.Id == id);

        }
    }
}
