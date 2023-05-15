using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RideSharingPlatform.Context;
using RideSharingPlatform.Microservices.IncidentManagement.BLL;
using RideSharingPlatform.Microservices.IncidentManagement.DAL;
using RideSharingPlatform.Microservices.IncidentManagement.DAL.Interface;
using RideSharingPlatform.Microservices.IncidentManagement.Models;
using RideSharingPlatform.Microservices.IncidentManagement.Models.DTO;


namespace RideSharingPlatform.Microservices.IncidentManagement.Controller
{
    [Route("api/")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly RideDbContext iDPDbContext;
        private readonly IMapper _mapper;
        private readonly IncidentService incidentService;

        public IncidentsController(RideDbContext context, IMapper mapper)
        {
            iDPDbContext = context;
            _mapper = mapper;
            incidentService = new IncidentService(context, _mapper);
        }

        [HttpPost]
        [Route("incidents/report")]
        [Authorize(Roles ="SecurityHead")]
        public IActionResult AddIncident([FromBody] IncidentDTOs incidentDTO)
        {
            var r = incidentService.AddIncident(incidentDTO);
            if (r)
            {
                return Ok("added");
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("incidents")]
        public IActionResult GetPendingStatus()
        {
            var incidents = incidentService.GetAllPendingIncidents();
           
            return Ok(incidents);

        }
        [HttpGet]
        [Route("incidents/<id>")]
        [ActionName("GetType")]
        public IActionResult GetType(string id)
        {
            var incidetTypes = incidentService.GetIncidentTypesById(id);
            if (incidetTypes == null)
            {
                return NotFound();
            }
            return Ok(incidetTypes);
        }
        [HttpPut]
        [Route("incidents/<id>/investigationreport")]
        public IActionResult UpdateIncident(string incidentId, string incidentDetails)
        {
            incidentService.UpdateIncident(incidentId, incidentDetails);
            return Ok("Success");
        }
    }
}
