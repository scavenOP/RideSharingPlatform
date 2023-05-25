using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RideSharingPlatform.Microservices.VehicleManagement.Models.DTOs
{
    public class RegisterVehicleDTO
    {
        [MaxLength(10)]
        [Key]
        //[RegularExpression(@"^\d{10}$", ErrorMessage = "Vehicle RegistrationNo must be of 10 digits")]
        public string RegistrationNo { get; set; }

       // [MaxLength(10)]
        public int BelongsToUserId { get; set; }

        //[MaxLength(10)]
        [ForeignKey("VehicleTypes")]
        public int VehicleTypeId { get; set; }
        

        [MaxLength(10)]
        [RegularExpression(@"^(pending|approved|rejected)$", ErrorMessage = "notvalid")]
        public string InspectionStatus { get; set; }
        
        [MaxLength(10)]
        public string RTOName { get; set; }

        [ReportDatePast(ErrorMessage = "Enter date should not be a past date")]
        public DateTime RegistrationDate { get; set; }


        public DateTime RegistrationExpiresOn { get; set; }

        

        [MaxLength(50)]
        public string InsuranceCompanyName { get; set; }

        [MaxLength(10)]
        public string InsuranceNo { get; set; }
        public DateTime InsurancedOn { get; set; }

        [ReportDatePast(ErrorMessage = "Enter date should not be a past date")]
        public DateTime InsuranceExpiresOn { get; set; }

        

       // [MaxLength(10)]
        public int PUCCertificateNo { get; set; }

        public DateTime PUCIssuedOn { get; set; }

        [ReportDatePast(ErrorMessage = "Enter date should not be a past date")]
        public DateTime PUCValidUntil { get; set; }

        


        public class ReportDatePast : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                DateTime dateTime = Convert.ToDateTime(value);
                return dateTime >= DateTime.Now;

            }



        }
    }
}
