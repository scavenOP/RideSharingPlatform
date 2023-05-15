using RideSharingPlatform.Context;
using RideSharingPlatform.Microservices.UserVerification.DAL.Interfaces;
using RideSharingPlatform.Microservices.UserVerification.Models;

namespace RideSharingPlatform.Microservices.UserVerification.DAL
{
    public class CompanyRepository : ICompanyRepository
    {
        private RideDbContext _context;

        public CompanyRepository(RideDbContext context)
        {
            _context = context;
        }

        public List<Company> GetAllCompanies()
        {
            return _context.Companies.ToList();
        }
    }
}
