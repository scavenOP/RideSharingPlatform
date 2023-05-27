using System.ComponentModel.DataAnnotations;

namespace RideSharingPlatform.Microservices.RideManagement.Models
{
    public class Distance
    {
        [Key]
        public int ID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int DistanceInKMS { get; set; }
    }
}
