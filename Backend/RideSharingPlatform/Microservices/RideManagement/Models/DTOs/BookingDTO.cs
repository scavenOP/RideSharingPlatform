using System.ComponentModel.DataAnnotations.Schema;

namespace RideSharingPlatform.Microservices.RideManagement.Models.DTOs
{
    public class BookingDTO
    {
        public DateTime BookedOn { get; set; }
        public int RiderUserId { get; set; }
        public int NoOfSeats { get; set; }
        //public int TotalAmount { get; set; }
        public string PaymentMode { get; set; }
        [ForeignKey("RideSchedules")]
        public int RideSchedulesID { get; set; }
    }
}
