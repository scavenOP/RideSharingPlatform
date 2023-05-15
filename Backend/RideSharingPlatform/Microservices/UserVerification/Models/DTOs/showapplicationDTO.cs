using System.ComponentModel.DataAnnotations;

namespace RideSharingPlatform.Microservices.UserVerification.Models.DTOs
{
    public class showapplicationDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string OfficialEmail { get; set; }
        
        public string PhoneNumber { get; set; }
        public string Designation { get; set; }

        public int RoleId { get; set; }
        public string EmployeeeId { get; set; }
        
        public string AadharNumber { get; set; }
        
        public string ApplicationStatus { get; set; }
        public int CompanyId { get; set; }
        public string? LicenseNo { get; set; }
        
        public DateTime? ExpirationDate { get; set; }
        public string? RTA { get; set; }
        public string? AlowedVehicles { get; set; }
    }
}
