using RideSharingPlatform.Microservices.RideManagement.Models;
using RideSharingPlatform.Microservices.RideManagement.Models.DTOs;

namespace RideSharingPlatform.Microservices.RideManagement.DAL.Interfaces
{
    public interface IRideRepository
    {
        List<Distance> GetDistances();
        int getFare(string regno);
        int AddRide(RideSchedule rideShedule);
        int getmotoristid(string regno);
        IEnumerable<RideSchedule> Search(SearchDTO searchdto);
        int BookRide(Booking booking);
        int GetRideFare(FareDTO fareDTO);
        string GetRegNo(int userId);


    }
}
