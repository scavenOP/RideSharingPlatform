using Microsoft.AspNetCore.Identity;
using RideSharingPlatform.Microservices.UserVerification.Models;

namespace RideSharingPlatform.Authentication.Models
{
    public class AuthUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
