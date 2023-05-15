using System.ComponentModel.DataAnnotations;

namespace RideSharingPlatform.Microservices.UserVerification.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
