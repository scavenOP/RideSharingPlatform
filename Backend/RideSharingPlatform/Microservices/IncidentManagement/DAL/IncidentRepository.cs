using RideSharingPlatform.Context;
using RideSharingPlatform.Microservices.IncidentManagement.Models.DTO;
using RideSharingPlatform.Microservices.IncidentManagement.Models;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;

namespace RideSharingPlatform.Microservices.IncidentManagement.DAL
{
    public class IncidentRepository
    {
        private readonly RideDbContext iDPDbContext;
        private readonly IMapper _mapper;

        public IncidentRepository(RideDbContext context, IMapper mapper)
        {
            iDPDbContext = context;
            _mapper = mapper;
        }
        public int AddIncident(Incident incident)
        {



            iDPDbContext.Incidents.Add(incident);
            return iDPDbContext.SaveChanges();


        }
        public IncidentTypes GetIncidentType(int id)
        {
            return iDPDbContext.IncidentTypes.FirstOrDefault(i => i.Id == id);
        }


        public IEnumerable<Incident> GetAllPendingIncidents()
        {
            return iDPDbContext.Incidents.Where(i => i.Status == "Pending").ToList();

        }

        public Incident GetIncidentTypesById(string id)
        {
            return iDPDbContext.Incidents.FirstOrDefault(i => i.IncidentID == id);

        }

        public int UpdateIncident(string id, string incidentReport)
        {
            var incident = iDPDbContext.Incidents.Find(id);
            if (incident != null)
            {
                incident.IncidentDetails = incidentReport;
                iDPDbContext.Incidents.Update(incident);
                return iDPDbContext.SaveChanges();
            }
            else
            {
                return 0;
            }
        }
    }
}

