using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RideSharingPlatform.Microservices.IncidentManagement.Models.DTO
{
    public class IncidentDTOs
    {


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
        //public virtual IncidentTypes IncidentTypes { get; set; }
    }
}
