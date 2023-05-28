using AutoMapper;
using RideSharingPlatform.Context;
using RideSharingPlatform.Microservices.RideManagement.DAL;
using RideSharingPlatform.Microservices.RideManagement.DAL.Interfaces;
using RideSharingPlatform.Microservices.RideManagement.Models;
using RideSharingPlatform.Microservices.RideManagement.Models.DTOs;

namespace RideSharingPlatform.Microservices.RideManagement.BLL
{
    public class RideService
    {
        private readonly RideDbContext _context;
        private readonly IRideRepository _repository;
        private IMapper _mapper;

        public RideService(RideDbContext context,IMapper mapper)
        {
            _context= context;
            _repository=new RideRepository(context);
            _mapper=mapper;
        }

        public List<Distance> GetDistances()
        {
            return _repository.GetDistances();
        }

        public bool SheduleRide(RideDTO ride)
        {
            var d = _context.Distances.FirstOrDefault(v => v.From==ride.RideFrom && v.To==v.To);
            RideSchedule rideSchedule=_mapper.Map<RideSchedule>(ride);

            rideSchedule.RideFare = _repository.getFare(ride.VehicleRegistrationNo) * d.DistanceInKMS;
            rideSchedule.MotoristUserId=_repository.getmotoristid(ride.VehicleRegistrationNo);
           int r =  _repository.AddRide(rideSchedule);
            if(r>0)
            {
                return true;
            }
            return false;
            


        }
        public IEnumerable<RideSchedule> SearchRide(SearchDTO ride)
        {
            return _repository.Search(ride);
        }

        public int BookRide(BookingDTO bookingDTO)
        {
            Booking booking = _mapper.Map<Booking>(bookingDTO);
            return _repository.BookRide(booking);
        }

        public int GetFare(FareDTO fare)
        {
            return _repository.GetRideFare(fare);
        }

        public string GetRegNo(int userid)
        {
            return _repository.GetRegNo(userid);
        }


    }
}
