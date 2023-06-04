using RideSharingPlatform.Context;
using RideSharingPlatform.Microservices.IncidentManagement.DAL.Interface;
using RideSharingPlatform.Microservices.IncidentManagement.Models;
using RideSharingPlatform.Microservices.IncidentManagement.Models.DTO;

namespace RideSharingPlatform.Microservices.IncidentManagement.DAL
{
    public class InvestigationRepository : IInvestigation
    {
        private readonly RideDbContext iDPDbContext;


        public InvestigationRepository(RideDbContext iDPDbContext)
        {
            this.iDPDbContext = iDPDbContext;
        }
        public int UpdateIncident(InvestigationDTO investigationDTO)
        {
            var incident = iDPDbContext.Incidents.FirstOrDefault(i => i.IncidentID == investigationDTO.IncidentId);



            if (incident != null)
            {
                incident.Status = investigationDTO.Status;



                var investigation = iDPDbContext.InvestigationDetails.FirstOrDefault(i => i.IncidentsIncidentId == investigationDTO.IncidentId);



                if (investigation != null)
                {
                    investigation.Finding = investigationDTO.Finding;
                    investigation.Suggestions = investigationDTO.Suggestions;
                    investigation.InverstigationDate = investigationDTO.InverstigationDate;



                    iDPDbContext.InvestigationDetails.Update(investigation);
                    return iDPDbContext.SaveChanges();
                }
                else
                {
                    // Create a new investigation if it doesn't exist
                    var newInvestigation = new InvestigationDetails
                    {
                        Finding = investigationDTO.Finding,
                        Suggestions = investigationDTO.Suggestions,
                        InverstigationDate = investigationDTO.InverstigationDate,
                        IncidentsIncidentId = investigationDTO.IncidentId
                    };



                    iDPDbContext.InvestigationDetails.Add(newInvestigation);
                    return iDPDbContext.SaveChanges();
                }
            }
            else
            {
                return 0; // Indicate that the incident was not found
            }
        }
        }
}
