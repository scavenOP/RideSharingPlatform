namespace RideSharingPlatform.Microservices.IncidentManagement.Models.DTO
{
    public class IncidentTypeDTOs
    {
        public int Id { get; set; }
        public string Types { get; set; }
        public int ExpectedSLAInDays { get; set; }
    }
}
