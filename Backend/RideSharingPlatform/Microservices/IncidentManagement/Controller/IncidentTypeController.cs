using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RideSharingPlatform.Microservices.IncidentManagement.DAL.Interface;
using RideSharingPlatform.Microservices.IncidentManagement.Models.DTO;

namespace RideSharingPlatform.Microservices.IncidentManagement.Controller
{
    [Route("api/")]
    [ApiController]
    public class IncidentTypeController : ControllerBase
    {
        private readonly IIncidentType incidentTypeRepository;

        public IncidentTypeController(IIncidentType incidentTypeRepository)
        {
            this.incidentTypeRepository = incidentTypeRepository;
        }
        [HttpGet]
        [Route("incidents/type")]
        public IActionResult Type()
        {
            var incidentTypesVar = incidentTypeRepository.GetIncidentTypes();

            var incidentTypeDTO = incidentTypesVar.Select(it => new IncidentTypeDTOs
            {
                Id = it.Id,
                Types = it.Types,
                ExpectedSLAInDays = it.ExpectedSLAInDays,
            }).ToList();

            return Ok(incidentTypeDTO);

            //return Ok(incidentTypesVar);
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetType(int id)
        {
            var types = incidentTypeRepository.GetIncidentTypesById(id);
            if (types == null)
            {
                return NotFound();
            }
            return Ok(types);
        }
    }
}
