using System.ComponentModel.DataAnnotations;

namespace RideSharingPlatform.Microservices.RideManagement.Models
{
    public class RideSchedule
    {
        [Key]
        public int ID { get; set; }
        public string RideFrom { get; set; }
        public string RideTo { get; set; }

        [CustomValidation(typeof(RideSchedule), "ValidateDate")]
        public DateTime RideStartsOn { get; set; }

        [CustomValidation(typeof(RideSchedule), "ValidateDate")]
        public string RideTime { get; set; }
        public int RideFare { get; set; }
        public string VehicleRegistrationNo { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Vehicle Registration Number must be 10 digits")]

        public int MotoristUserId { get; set; }
        public int NoOfSeatsAvailable { get; set; }
        public static ValidationResult ValidateDate(DateTime value, ValidationContext context)
        {
            if (value.Date < DateTime.Today)
            {
                return new ValidationResult("Date must not be a past date");
            }
            return ValidationResult.Success;
        }
    }
}
