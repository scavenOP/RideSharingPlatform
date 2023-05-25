using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RideSharingPlatform.Microservices.VehicleManagement.Models.DTOs
{
    public class UpdateVehiceDTO
    {
        
        //[RegularExpression(@"^\d{10}$", ErrorMessage = "Vehicle RegistrationNo must be of 10 digits")]
        public string RegistrationNo { get; set; }

        

        
        [RegularExpression(@"^(pending|approved|rejected)$", ErrorMessage = "notvalid")]
        public string InspectionStatus { get; set; }

        
        public int InspectionByUserId { get; set; }
        public DateTime InspectedOn { get; set; }
    }
}
