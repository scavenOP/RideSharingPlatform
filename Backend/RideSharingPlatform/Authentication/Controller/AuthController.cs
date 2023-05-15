using AutoMapper;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RideSharingPlatform.Authentication.helper;
using RideSharingPlatform.Authentication.Models;
using RideSharingPlatform.Context;
using System.Security.Claims;

namespace RideSharingPlatform.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private RideDbContext _context;
        private readonly IConfiguration _configuration;
        private IMapper _mapper;

        public AuthController(RideDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            this._configuration = configuration;
            _mapper = mapper;
        }
        [Route("login")]
        [HttpPost]
        public IActionResult Login(LoginRequestModel loginModel)
        {
            var hashedPass = loginModel.Password;
            AuthUser user = _context.AuthUser.Include(o => o.Role).SingleOrDefault(x => x.Email == loginModel.email && x.Password == hashedPass);

            if (user is null)
                return Unauthorized("Invalid Username or Password!");

            string role;
            var token = JWT.GenerateToken(new Dictionary<string, string> {
                { ClaimTypes.Role, user.Role.Name  },
                { "RoleId", user.Role.Id.ToString() },
                {JwtClaimTypes.PreferredUserName, user.UserName },
                { JwtClaimTypes.Id, user.Id.ToString() },
                { JwtClaimTypes.Email, user.Email}
            }, _configuration["JWT:Key"]);

            if (user.RoleId == 1)
            {
                role = "Motorist";
            }
            else if (user.RoleId == 2)
            {
                role = "Rider";
            }
            else
            {
                role = "SecurityHead";
            }
           
            return Ok(new AuthResponse { Id=user.Id ,  token = token, Name=user.UserName , Role=role });
        }
    }
}
