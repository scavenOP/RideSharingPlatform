using RideSharingPlatform.Context;
using RideSharingPlatform.Microservices.IncidentManagement.Models.DTO;
using RideSharingPlatform.Microservices.IncidentManagement.Models;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using RideSharingPlatform.Microservices.IncidentManagement.DAL.Interface;

namespace RideSharingPlatform.Microservices.IncidentManagement.DAL
{
    public class IncidentRepository :IIncident
    {
        private readonly RideDbContext iDPDbContext;


        public IncidentRepository(RideDbContext iDPDbContext)
        {
            this.iDPDbContext = iDPDbContext;
        }

        public string AddIncident(IncidentDTOs incidentDTOs)
        {
            var unique = GetUniqueIncidentId();
            var incidentId = incidentDTOs.IncidentDate.Year.ToString() + "-" + unique;
            var domainModel = new Incident
            {
                IncidentID = incidentId,
                IncidentDate = incidentDTOs.IncidentDate,
                ReportDate = incidentDTOs.ReportDate,
                IncidentReportedByUserId = incidentDTOs.IncidentReportedByUserId,
                ResolutionETA = incidentDTOs.ResolutionETA,
                InvestigatedByUserId = incidentDTOs.InvestigatedByUserId,
                IncidentSummary = incidentDTOs.IncidentSummary,
                IncidentDetails = incidentDTOs.IncidentDetails,
                BookingId = incidentDTOs.BookingId,
                Status = incidentDTOs.Status,
                IncidentTypeId = incidentDTOs.IncidentTypeId,
                //IncidentTypes = incidentDTOs.IncidentTypes,
            };
            iDPDbContext.Incidents.Add(domainModel);
            iDPDbContext.SaveChanges();
            return incidentId;

        }
        public string GetUniqueIncidentId()
        {
            Random random = new Random();
            int value = random.Next(1000, 10000);
            string uniquenum = Convert.ToString(value);
            return $"{uniquenum}";
        }

        public IEnumerable<Incident> GetAllPendingIncidents()
        {
            return iDPDbContext.Incidents.Where(i => i.Status == "Pending").ToList();

        }

        public Incident GetIncidentTypesById(string id)
        {
            return iDPDbContext.Incidents.FirstOrDefault(i => i.IncidentID == id);

        }

        //public int UpdateIncident(string incidentID)
        //{
        //    var incident = iDPDbContext.Incidents.Find(incidentID);
        //    if (incident)
        //    {

        //    }
        //    else
        //    {
        //        return NotFoundResult();
        //    }
        //}



        //public string CreateIncident(IncidentDTOs incidentDTO)
        //{
        //    var unique = GetUniqueIncidentId();
        //    var incidentId = incidentDTO.IncidentDate.Year.ToString() + "-" + unique;

        //    iDPDbContext.Incidents.Add(incidentId);
        //}
    }
}

