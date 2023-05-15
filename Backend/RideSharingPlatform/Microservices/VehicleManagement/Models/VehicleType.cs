using System.ComponentModel.DataAnnotations;

namespace RideSharingPlatform.Microservices.VehicleManagement.Models
{
    public class VehicleType
    {
       // [MaxLength(10)]
        [Key]
        public int ID { get; set; }

        [MaxLength(10)]
        public string Type { get; set; }

       // [MaxLength(10)]
        public int MaxPassengersAllowed { get; set; }

        //[MaxLength(10)]
        public int FarePerKM { get; set; }
    }
}
