using System.ComponentModel.DataAnnotations;

namespace RideSharingPlatform.Microservices.VehicleManagement.Models
{
    public class VehicleDetail
    {
        
            [MaxLength(10)]
            [Key]
            public string RegistrationNo { get; set; }
            [MaxLength(10)]
            public string RTOName { get; set; }

            [ReportDatePast(ErrorMessage = "Enter date should not be a past date")]
            public DateTime RegistrationDate { get; set; }


            public DateTime RegistrationExpiresOn { get; set; }

            [MaxLength(100)]
            public string RCDocURL { get; set; }

            [MaxLength(50)]
            public string InsuranceCompanyName { get; set; }

            [MaxLength(10)]
            public string InsuranceNo { get; set; }
            public DateTime InsurancedOn { get; set; }

            [ReportDatePast(ErrorMessage = "Enter date should not be a past date")]
            public DateTime InsuranceExpiresOn { get; set; }

            [MaxLength(100)]
            public string InsuranceCertificateDOCURL { get; set; }

            //[MaxLength(10)]
            public int PUCCertificateNo { get; set; }

            public DateTime PUCIssuedOn { get; set; }

            [ReportDatePast(ErrorMessage = "Enter date should not be a past date")]
            public DateTime PUCValidUntil { get; set; }

            [MaxLength(100)]
            public string PUCDOCURL { get; set; }


            public class ReportDatePast : ValidationAttribute
            {
                public override bool IsValid(object value)
                {
                    DateTime dateTime = Convert.ToDateTime(value);
                    return dateTime >= DateTime.Now;

                }



            }

        }
    }


