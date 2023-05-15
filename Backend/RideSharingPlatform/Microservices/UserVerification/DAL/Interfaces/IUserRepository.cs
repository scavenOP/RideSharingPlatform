using RideSharingPlatform.Authentication.Models;
using RideSharingPlatform.Microservices.UserVerification.Models;

namespace RideSharingPlatform.Microservices.UserVerification.DAL.Interfaces
{
    public interface IUserRepository
    {
        int InsertnewApplication(UserApplication user, DrivingLicense license);
        List<UserApplication> GetPendingApplications();
        UserApplication GetPendingApplicationByUserId(int userId);
        int RejectApplication(UserApplication application);
        int ApproveApplication(UserApplication application, AuthUser user);
        DrivingLicense GetDrivingLicense(int id);


    }
}
