using System.ComponentModel.DataAnnotations;

namespace RideSharingPlatform.Authentication.Models
{
    public class LoginRequestModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string email { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Password { get; set; } = null;
    }
}
