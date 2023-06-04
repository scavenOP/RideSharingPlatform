using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RideSharingPlatform.Context;

using RideSharingPlatform.Microservices.IncidentManagement.DAL;
using RideSharingPlatform.Microservices.IncidentManagement.DAL.Interface;
using RideSharingPlatform.Microservices.IncidentManagement.Models;
using RideSharingPlatform.Microservices.IncidentManagement.Models.DTO;


namespace RideSharingPlatform.Microservices.IncidentManagement.Controller
{
    [Route("api/")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IIncident incident;

        public IncidentController(IIncident incident)
        {
            this.incident = incident;
        }

        [HttpPost]
        [Route("incidents/report")]
        public IActionResult AddIncident(IncidentDTOs incidentDTOs)
        {

            //var incident = new Incident()
            //{
            //    IncidentDate = incidentDTOs.IncidentDate,
            //    ReportDate = incidentDTOs.ReportDate,
            //    IncidentReportedByUserId = incidentDTOs.IncidentReportedByUserId,
            //    ResolutionETA = incidentDTOs.ResolutionETA,
            //    InvestigatedByUserId = incidentDTOs.InvestigatedByUserId,
            //    IncidentSummary = incidentDTOs.IncidentSummary,
            //    IncidentDetails = incidentDTOs.IncidentDetails,
            //    BookingId = incidentDTOs.BookingId,
            //    Status = incidentDTOs.Status,
            //    IncidentTypeId = incidentDTOs.IncidentTypeId,

            //};

            var incidentId = incident.AddIncident(incidentDTOs);

            //return CreatedAtAction(nameof(GetType), new { id = incidentId }, incidentDTOs);
            return Ok(new { IncidentId = incidentId });
        }
        [HttpGet]
        [Route("incidents")]
        public IActionResult GetPendingStatus()
        {
            var incidents = incident.GetAllPendingIncidents();
            var result = incidents.Select(i => new {
                i.IncidentID,
                i.IncidentDate,
                i.ReportDate,
                i.IncidentReportedByUserId,
                i.ResolutionETA,
                i.InvestigatedByUserId,
                i.IncidentSummary,
                i.IncidentDetails,
                i.BookingId,
                i.Status,


            });
            return Ok(result);

        }

        [HttpGet]
        [Route("incidents/{incidentID}")]
        [ActionName("GetType")]
        public IActionResult GetType([FromRoute] string incidentID)
        {
            var incidetTypes = incident.GetIncidentTypesById(incidentID);
            if (incidetTypes == null)
            {
                return NotFound();
            }
            return Ok(incidetTypes);
        }
        //[HttpPut]
        //[Route("incidents/update/{incidentID}")]
        //public IActionResult UpdateIncident(string incidentID)

        //{
        //    incident.UpdateIncident(incidentID);
        //    return Ok("Success");
        //}
    }
}
