using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RideSharingPlatform.Context;
using RideSharingPlatform.Microservices.RideManagement.BLL;
using RideSharingPlatform.Microservices.RideManagement.Models.DTOs;

namespace RideSharingPlatform.Microservices.RideManagement.Controller
{
    [Route("api/")]
    [ApiController]
    public class RideController : ControllerBase
    {
        private readonly RideDbContext _context;
        private readonly RideService _service;

        public RideController(RideDbContext context,IMapper mapper)
        {
            _context = context;
            _service = new RideService(_context,mapper);
        }

        [HttpGet]
        [Route("distances")]
        public IActionResult GetDistances()
        {
            var r = _service.GetDistances();
            return Ok(r);
        }

        [HttpGet]
        [Route("rides/calculatefare")]
        public IActionResult GetRideFare([FromQuery] FareDTO fareDTO)
        {
            var r =_service.GetFare(fareDTO);
            return Ok(r);
        }

        [HttpPost]
        [Route("rides/schedule")]
         public IActionResult ScheduleRide([FromBody] RideDTO rideDTO)
        {
            var r =_service.SheduleRide(rideDTO);
            return Ok(r);
        }

        [HttpGet]
        [Route("rides/search")]
        public IActionResult SearchRides([FromQuery] SearchDTO searchDTO) { 
            var r = _service.SearchRide(searchDTO);
            return Ok(r);
        }

        [HttpPost]
        [Route("rides/book")]
        public IActionResult BookRide([FromBody] BookingDTO bookingDTO)
        {
            var r = _service.BookRide(bookingDTO);
            return Ok(r);
        }

        [HttpGet]
        [Route("GetRegNo/{userId}")]
        public IActionResult GetRegNo(int userId)
        {
            var r =_service.GetRegNo(userId);
            return Ok(r);
        }
        

    }
}
