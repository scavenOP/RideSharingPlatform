using System.ComponentModel.DataAnnotations;

namespace RideSharingPlatform.Microservices.UserVerification.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string BuildingName { get; set; }
        public string SecurityInChargeName { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Security Help Desk number must be 10 digits")]
        public string SecurityHelpDeskNumber { get; set; }
    }
}
