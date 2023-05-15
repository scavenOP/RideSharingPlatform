using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace RideSharingPlatform.Microservices.UserVerification.Models
{
    public class UserApplication
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string OfficialEmail { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits")]
        public string PhoneNumber { get; set; }
        public string Designation { get; set; }

        [RegularExpression(@"^(Motorist|Rider|SecurityHead)$", ErrorMessage = "Invalid Role")]
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public string EmployeeeId { get; set; }
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Aadhar number must be 12 digits")]
        public string AadharNumber { get; set; }
        [RegularExpression(@"^(New|Approved|Rejected)$", ErrorMessage = "ffgg")]
        public string ApplicationStatus { get; set; }
        public int CompanyId { get; set; }
        public  virtual Company Company { get; set; }
        public string Password { get; set; }
    }
}
