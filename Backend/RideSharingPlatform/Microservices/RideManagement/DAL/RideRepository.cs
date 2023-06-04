using RideSharingPlatform.Context;
using RideSharingPlatform.Microservices.RideManagement.DAL.Interfaces;
using RideSharingPlatform.Microservices.RideManagement.Models;
using RideSharingPlatform.Microservices.RideManagement.Models.DTOs;
using RideSharingPlatform.Microservices.VehicleManagement.Models;

namespace RideSharingPlatform.Microservices.RideManagement.DAL
{
    public class RideRepository : IRideRepository
    {
        private readonly RideDbContext _context;

        public RideRepository(RideDbContext context)
        {
            _context = context;
        }

        public List<Distance> GetDistances()
        {
            return _context.Distances.ToList();
        }

        public int AddRide(RideSchedule rideShedule)
        {
            _context.RideSchedules.Add(rideShedule);
            return _context.SaveChanges();
        }
        public int GetRideFare(FareDTO fareDTO)
        {
            var d = _context.Distances.FirstOrDefault(d => d.ID == fareDTO.DistanceID);
            int f = getFare(fareDTO.VehicleRegistrationNo) * d.DistanceInKMS;
            return f;
        }
        public int getFare(string regno)
        {
            var vehicle= _context.Vehicles.FirstOrDefault(v => v.RegistrationNo== regno);
            if (vehicle == null)
            {
                return 0;
            }
            var vehicletype = _context.VehicleTypes.FirstOrDefault(v => v.ID == vehicle.VehicleTypeId);

            return vehicletype.FarePerKM;
        }
        public int getmotoristid(string regno)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(v => v.RegistrationNo == regno);
            return vehicle.BelongsToUserId;
        }
        public IEnumerable<RideSchedule> Search(SearchDTO searchdto)
        {
            IEnumerable<RideSchedule> v = _context.RideSchedules.ToList();
            if(searchdto.From!= null)
            {
                v = v.Where(s => s.RideFrom == searchdto.From);
            }
            if (searchdto.To != null)
            {
                v = v.Where(s => s.RideTo == searchdto.To);
            }
            if (searchdto.MaxPrice != null)
            {
                v = v.Where(s => s.RideFare<=searchdto.MaxPrice);
            }
            if (searchdto.MinPrice != null)
            {
                v = v.Where(s => s.RideFare >= searchdto.MinPrice);
            }
            return v;
        }
        public int BookRide(Booking booking)
        {
            booking.RideSchedule = _context.RideSchedules.FirstOrDefault(r => r.ID == booking.RideSchedulesID);
            booking.TotalAmount = booking.NoOfSeats * booking.RideSchedule.RideFare;
            _context.Bookings.Add(booking);
            var r = _context.RideSchedules.FirstOrDefault(r => r.ID==booking.RideSchedulesID);
            r.NoOfSeatsAvailable -= booking.NoOfSeats;
            _context.SaveChanges();
            return booking.BookingID;
        }

        public string GetRegNo(int userId)
        {
            Vehicle v = _context.Vehicles.FirstOrDefault(v => v.BelongsToUserId== userId);

            return v.RegistrationNo;
        }
    }
}
