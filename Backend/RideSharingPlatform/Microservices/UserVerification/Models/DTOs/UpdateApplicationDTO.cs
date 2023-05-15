using System.ComponentModel.DataAnnotations;

namespace RideSharingPlatform.Microservices.UserVerification.Models.DTOs
{
    public class UpdateApplicationDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string OfficialEmail { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits")]
        public string PhoneNumber { get; set; }
        public string Designation { get; set; }
        
        public int RoleId { get; set; }
        
        public string EmployeeeId { get; set; }
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Aadhar number must be 12 digits")]
        public string AadharNumber { get; set; }
        [RegularExpression(@"^(New|Approved|Rejected)$", ErrorMessage = "Invalid Application Status")]
        public string ApplicationStatus { get; set; }
        public int CompanyId { get; set; }


        public string LicenseNo { get; set; }
        [CustomValidation(typeof(DrivingLicense), "ValidateExpirationDate")]
        public DateTime ExpirationDate { get; set; }
        public string RTA { get; set; }
        public string AlowedVehicles { get; set; }



        public static ValidationResult ValidateExpirationDate(DateTime value, ValidationContext context)
        {
            if (value.Date < DateTime.Today)
            {
                return new ValidationResult("Expiration date must not be a past date");
            }
            return ValidationResult.Success;
        }
    }
}
