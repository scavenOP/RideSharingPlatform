using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RideSharingPlatform.Microservices.IncidentManagement.Models
{
    public class Incident
    {

        public string IncidentID { get; set; }
        [CustomValidation(typeof(Incident), "ValidateIncidentDate")]
        public DateTime IncidentDate { get; set; }

        [CustomValidation(typeof(Incident), "ValidateReportDate")]
        public DateTime ReportDate { get; set; }
        public int IncidentReportedByUserId { get; set; }

        public DateTime ResolutionETA { get; set; }
        public int InvestigatedByUserId { get; set; }

        public string IncidentSummary { get; set; }
        public string IncidentDetails { get; set; }
        public int BookingId { get; set; }
        [DefaultValue("Pending")]
        public string Status { get; set; }
        [ForeignKey("IncidentTypes")]
        public int IncidentTypeId { get; set; }
        //public IncidentTypes IncidentTypes { get; set; }


        public static ValidationResult ValidateReportDate(DateTime value, ValidationContext context)
        {
            if (value.Date > DateTime.Today)
            {
                return new ValidationResult("Report date should not be a future date");
            }
            return ValidationResult.Success;
        }

        public static ValidationResult ValidateIncidentDate(DateTime value, ValidationContext context)
        {
            if (value.Date > DateTime.Today)
            {
                return new ValidationResult("Incident date can be today or a past date only");
            }
            return ValidationResult.Success;
        }
    }
}
