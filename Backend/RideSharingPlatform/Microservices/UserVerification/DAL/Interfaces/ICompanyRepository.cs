using RideSharingPlatform.Microservices.UserVerification.Models;

namespace RideSharingPlatform.Microservices.UserVerification.DAL.Interfaces
{
    public interface ICompanyRepository
    {
        List<Company> GetAllCompanies();
    }
}
