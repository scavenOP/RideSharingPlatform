using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RideSharingPlatform.Context;
using RideSharingPlatform.Microservices.UserVerification.BLL;
using RideSharingPlatform.Microservices.UserVerification.DAL;
using RideSharingPlatform.Microservices.UserVerification.DAL.Interfaces;
using RideSharingPlatform.Microservices.UserVerification.Models.DTOs;
using static System.Net.Mime.MediaTypeNames;

namespace RideSharingPlatform.Microservices.UserVerification.Controller
{
    [Route("api/")]
    [ApiController]
    public class applicationsController : ControllerBase
    {
        private UserService _userApplication;
        private RideDbContext _context;
        private IMapper _mapper;
        private ICompanyRepository _companyrepository;
        private IUserRepository _userRepository;

        public applicationsController(RideDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _companyrepository = new CompanyRepository(_context);
            _userRepository= new UserRepository(_context);
            _userApplication = new UserService(_userRepository,_companyrepository,_mapper);
        }
        [HttpPost]
        [Route("applications/new")]
        [Consumes(contentType: "application/json")]
        public IActionResult New([FromBody] NewApplicationDTO application)
        {
            var result = _userApplication.CreateNewApplication(application);

            if (result)
            {
                return Ok(result);
            }
            return StatusCode(500);

        }
        [HttpGet("companies")]

        public IActionResult GetAllCompanies()
        {
            var companies = _companyrepository.GetAllCompanies();
            return Ok(companies);

        }

        [HttpGet("applications")]
        //[Authorize()]
        public IActionResult GetAllPendingApplication()
        {
            var pending = _userApplication.GetAllPendingApplications();
            return Ok(pending);
        }

        [HttpGet]
        [Route("applications/{userId}")]
        public IActionResult GetPendingApplicationByUserId(int userId)
        {
            var application = _userApplication.GetPendingApplicationById(userId);
            return Ok(application);
        }
        [HttpPut]
        [Route("applications/approvereject")]
        [Consumes(contentType: "application/json")]
        public IActionResult UpdateApplication([FromBody] UpdateApplicationDTO application)
        {
            var r = _userApplication.UpdateApplication(application);

            if (r)
            {
                return Ok(new { Message= "Updated"});
            }
            return StatusCode(500);

        }
    }
}
