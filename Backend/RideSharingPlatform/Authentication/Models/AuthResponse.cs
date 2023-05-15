using RideSharingPlatform.Microservices.UserVerification.Models;

namespace RideSharingPlatform.Authentication.Models
{
    public class AuthResponse
    {
        public int Id { get; set; }
        public string token { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
