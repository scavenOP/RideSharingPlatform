using System.ComponentModel.DataAnnotations.Schema;

namespace RideSharingPlatform.Microservices.IncidentManagement.Models
{
    public class InvestigationDetails
    {
        public int Id { get; set; }
        public string Finding { get; set; }
        public string Suggestions { get; set; }
        public DateTime InverstigationDate { get; set; }

        [ForeignKey("Incident")]
        public string IncidentsIncidentId { get; set; }
        public virtual Incident Incident { get; set; }
    }
}
