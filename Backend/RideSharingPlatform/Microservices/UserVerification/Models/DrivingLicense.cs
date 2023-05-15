using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RideSharingPlatform.Microservices.UserVerification.Models
{
    public class DrivingLicense
    {
        [Key]
        public int Id { get; set; }
        public string LicenseNo { get; set; }
        [CustomValidation(typeof(DrivingLicense), "ValidateExpirationDate")]
        public DateTime ExpirationDate { get; set; }
        public string RTA { get; set; }
        public string AlowedVehicles { get; set; }
        [ForeignKey("UserApplication")]
        public int UserId { get; set; }
        public  virtual UserApplication User { get; set; }

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
