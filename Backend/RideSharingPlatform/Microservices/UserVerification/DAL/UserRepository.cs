using Microsoft.EntityFrameworkCore;
using RideSharingPlatform.Authentication.Models;
using RideSharingPlatform.Context;
using RideSharingPlatform.Microservices.UserVerification.DAL.Interfaces;
using RideSharingPlatform.Microservices.UserVerification.Models;

namespace RideSharingPlatform.Microservices.UserVerification.DAL
{
    public class UserRepository : IUserRepository
    {
        private RideDbContext _context;

        public UserRepository(RideDbContext context)
        {
            _context = context;
        }

        public int InsertnewApplication(UserApplication user, DrivingLicense license)
        {
            user.Role = _context.Roles.SingleOrDefault(u => u.Id == user.RoleId);

            _context.UserApplications.Add(user);
            
                if (user.RoleId == 1) {
                _context.SaveChanges();
                license.UserId = user.UserId;
                _context.DrivingLicenses.Add(license); }
            return _context.SaveChanges();


        }
        public List<UserApplication> GetPendingApplications()
        {

            return _context.UserApplications.Where(u => u.ApplicationStatus == "New").Include(u => u.Company).ToList();
        }
        public UserApplication GetPendingApplicationByUserId(int userId)
        {
            return _context.UserApplications.FirstOrDefault(u => u.ApplicationStatus == "New" && u.UserId == userId);
        }

        public int RejectApplication(UserApplication application)
        {
            _context.Entry(application).State = EntityState.Modified;
            
            return  _context.SaveChanges();
            
        }
        public int ApproveApplication(UserApplication application,AuthUser user)
        {
            _context.Entry(application).State = EntityState.Modified;

            
            _context.AuthUser.Add(user);
            return _context.SaveChanges();
            

        }
        public DrivingLicense GetDrivingLicense(int id)
        {
            return _context.DrivingLicenses.FirstOrDefault(d => d.UserId == id);

        }
        
    }
}
