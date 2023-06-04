using System.ComponentModel.DataAnnotations.Schema;

namespace RideSharingPlatform.Microservices.IncidentManagement.Models.DTO
{
    public class InvestigationDTO
    {
        public string Finding { get; set; }
        public string Suggestions { get; set; }
        public DateTime InverstigationDate { get; set; }

        [ForeignKey("Incident")]
        public string IncidentId { get; set; }
        //public virtual Incident Incident { get; set; }

        public string Status { get; set; }
    }
}
