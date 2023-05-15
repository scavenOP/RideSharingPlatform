namespace RideSharingPlatform.Microservices.IncidentManagement.Models
{
    public class IncidentTypes
    {
        public int Id { get; set; }
        public string Types { get; set; }
        public int ExpectedSLAInDays { get; set; }
    }
}
