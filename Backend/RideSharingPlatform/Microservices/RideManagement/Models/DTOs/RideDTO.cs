using System.ComponentModel.DataAnnotations;

namespace RideSharingPlatform.Microservices.RideManagement.Models.DTOs
{
    public class RideDTO
    {
        
        public string RideFrom { get; set; }
        public string RideTo { get; set; }

        
        public DateTime RideStartsOn { get; set; }

        public string RideTime { get; set; }
        //public int RideFare { get; set; }
        public string VehicleRegistrationNo { get; set; }
       

        public int MotoristUserId { get; set; }
        public int NoOfSeatsAvailable { get; set; }
    }

}
