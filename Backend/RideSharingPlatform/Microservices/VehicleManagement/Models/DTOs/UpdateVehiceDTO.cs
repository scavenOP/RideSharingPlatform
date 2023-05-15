using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RideSharingPlatform.Microservices.VehicleManagement.Models.DTOs
{
    public class UpdateVehiceDTO
    {
        [MaxLength(10)]
        [Key]
        //[RegularExpression(@"^\d{10}$", ErrorMessage = "Vehicle RegistrationNo must be of 10 digits")]
        public string RegistrationNo { get; set; }

        public int BelongsToUserId { get; set; }

        
        [ForeignKey("VehicleTypes")]
        public int VehicleTypeId { get; set; }
        public virtual VehicleType VehicleType { get; set; }

        [MaxLength(10)]
        [RegularExpression(@"^(pending|approved|rejected)$", ErrorMessage = "notvalid")]
        public string InspectionStatus { get; set; }

        
        public int InspectionByUserId { get; set; }
        public DateTime InspectedOn { get; set; }
    }
}
