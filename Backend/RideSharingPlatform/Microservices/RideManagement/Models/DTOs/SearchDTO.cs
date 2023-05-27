namespace RideSharingPlatform.Microservices.RideManagement.Models.DTOs
{
    public class SearchDTO
    {
        public string? From { get; set; }
        public string? To { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
    }
}
