using AutoMapper;
using RideSharingPlatform.Context;
using RideSharingPlatform.Microservices.IncidentManagement.BLL.Exceptions;
using RideSharingPlatform.Microservices.IncidentManagement.DAL;
using RideSharingPlatform.Microservices.IncidentManagement.Models;
using RideSharingPlatform.Microservices.IncidentManagement.Models.DTO;

namespace RideSharingPlatform.Microservices.IncidentManagement.BLL
{
    public class IncidentService
    {
        private readonly RideDbContext iDPDbContext;
        private readonly IMapper _mapper;
        private readonly IncidentRepository incidentRepository;

        public IncidentService(RideDbContext context, IMapper mapper)
        {
            iDPDbContext = context;
            _mapper = mapper;
            incidentRepository = new IncidentRepository(context, _mapper);
        }

        public bool AddIncident(IncidentDTOs incidentDTO)
        {
            Incident incident = _mapper.Map<Incident>(incidentDTO);
            var unique = GetUniqueIncidentId();
            incident.IncidentID= incidentDTO.IncidentDate.Year.ToString() + "-" + unique;
            incident.IncidentTypes = incidentRepository.GetIncidentType(incident.IncidentTypeId);

            incident.ResolutionETA = incident.ReportDate.AddDays(incident.IncidentTypes.ExpectedSLAInDays);

            if((DateTime.Today - incident.IncidentDate).TotalDays > 2)
            {
                throw new CannotReportIncidentException("Incident cannot be registered");
            }
           

            var r = incidentRepository.AddIncident(incident);

            if (r > 0)
            {
                return true;
            }
            return false;

        }
        public IEnumerable<Incident> GetAllPendingIncidents()
        {
            return incidentRepository.GetAllPendingIncidents();
        }
        public Incident GetIncidentTypesById(string id)
        {
            return incidentRepository.GetIncidentTypesById(id);

        }
        public int UpdateIncident(string id, string incidentReport)
        {
            return incidentRepository.UpdateIncident(id, incidentReport);
        }


        public string GetUniqueIncidentId()
        {
            Random random = new Random();
            int value = random.Next(1000, 10000);
            string uniquenum = Convert.ToString(value);
            return $"{uniquenum}";
        }
    }
}
