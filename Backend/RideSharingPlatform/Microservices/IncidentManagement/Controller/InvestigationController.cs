using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RideSharingPlatform.Microservices.IncidentManagement.DAL.Interface;
using RideSharingPlatform.Microservices.IncidentManagement.Models.DTO;

namespace RideSharingPlatform.Microservices.IncidentManagement.Controller
{
    [Route("api/")]
    [ApiController]
    public class InvestigationController : ControllerBase
    {
        private readonly IInvestigation investigation;

        public InvestigationController(IInvestigation investigation)
        {
            this.investigation = investigation;
        }


        [HttpPut]
        [Route("incidents/{incidentID}/investigationreport")]
        public IActionResult UpdateIncident(InvestigationDTO investigationDTO)

        {
            investigation.UpdateIncident(investigationDTO);
            return Ok("Success");
        }
    }
}
