using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RideSharingPlatform.Microservices.VehicleManagement.Models
{
    public class Vehicle
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
        public virtual VehicleType VehicleType { get; set; }

            [MaxLength(10)]
            [RegularExpression(@"^(pending/approved/rejected)$", ErrorMessage = "notvalid")]
            public string InspectionStatus { get; set; }

            //[MaxLength(10)]
            public int? InspectionByUserId { get; set; }
            public DateTime? InspectedOn { get; set; }
        }
    }



