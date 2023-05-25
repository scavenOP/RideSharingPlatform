using AutoMapper;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RideSharingPlatform.Context;
using RideSharingPlatform.Microservices.VehicleManagement.BLL;
using RideSharingPlatform.Microservices.VehicleManagement.DAL.Interfaces;
using RideSharingPlatform.Microservices.VehicleManagement.Models.DTOs;
using System.Security.Claims;

namespace RideSharingPlatform.Microservices.VehicleManagement.Controller
{
    [Route("api/")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private IMapper _mapper;
        private RideDbContext _context;
        private VehicleService vehicleService;

        public VehicleController(IMapper mapper, RideDbContext context)
        {
            _mapper=mapper;
            _context = context;
            this.vehicleService = new VehicleService(_context,_mapper);
        }

        [Route("vehicles/vehicletypes")]
        [HttpGet]
        [Authorize(Roles ="Motorist")]
        public IActionResult GetAllVehicleTypes()
        {
            return Ok(vehicleService.GetAllVehicleTypes());
        }

        [Route("vehicles/add/vehicle")]
        [HttpPost]
        [Authorize(Roles = "Motorist")]
        public IActionResult AddNewVehicle([FromBody] RegisterVehicleDTO registerVehicleDTO)
        {
            var r = vehicleService.insertVehicle(registerVehicleDTO);
            if (r)
            {
                return Ok(r);
            }
            return BadRequest();
        }
        
        [Route("vehicles/delete/{regno}")]
        [HttpDelete]
        [Authorize(Roles = "Motorist")]
        public IActionResult DeleteVehicle(string regno)
        {

            var id = User.Claims.Where(c => c.Type == JwtClaimTypes.Id).Single().Value;
            var r = vehicleService.deletevehicle(regno, Convert.ToInt32(id));

            if (r)
            {
                return Ok(r);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("vehicle/{userid}")]
        public IActionResult GetVehicle(int userid)
        {
            var r = vehicleService.Getvehiclebyuserid(userid);
            return Ok(r);
        }

        [HttpGet]
        [Route("vehicle/pendingvehicles")]
        [Authorize(Roles = "SecurityHead")]
        public IActionResult GetPendingVehicles()
        {
            var r = vehicleService.GetAllPendingVehicles();
            return Ok(r);
        }

        [HttpPut]
        [Route("vehicles/approveorreject")]
        //[Authorize(Roles = "SecurityHead")]
        public IActionResult UpdateVehicleStatus([FromBody] UpdateVehiceDTO updateVehiceDTO)
        {
            var r = vehicleService.UpdateVehicleStatus(updateVehiceDTO);
            if (r)
            {
                return Ok(r);

            }
            return BadRequest();
        }

    }
}
