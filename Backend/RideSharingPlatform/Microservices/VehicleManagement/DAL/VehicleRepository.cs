using AutoMapper;
using RideSharingPlatform.Context;
using RideSharingPlatform.Microservices.VehicleManagement.BLL.Exceptions;
using RideSharingPlatform.Microservices.VehicleManagement.DAL.Interfaces;
using RideSharingPlatform.Microservices.VehicleManagement.Models;
using RideSharingPlatform.Microservices.VehicleManagement.Models.DTOs;

namespace RideSharingPlatform.Microservices.VehicleManagement.DAL
{
    public class VehcileRepository : IVehicleRepository
    {
        private RideDbContext _context;
        private IMapper _mapper;

        public VehcileRepository(RideDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper= mapper;
        }
        public List<VehicleType> GetVehicleTypes()
        {
            return _context.VehicleTypes.ToList();
        }

        public int InsertVehicle(RegisterVehicleDTO registerVehicleDTO)
        {
            Vehicle vehicle = _mapper.Map<Vehicle>(registerVehicleDTO);
            VehicleDetail vehicleDetail = _mapper.Map<VehicleDetail>(registerVehicleDTO);
            _context.Vehicles.Add(vehicle);
            _context.VehicleDetails.Add(vehicleDetail);
            return _context.SaveChanges();
        }

        public int DeleteVehicle(  string registtrationNo,int userid)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(v => v.RegistrationNo == registtrationNo);
            var vehicledetail = _context.VehicleDetails.FirstOrDefault(v => v.RegistrationNo == registtrationNo);
            if (vehicle.BelongsToUserId != userid)
            {
                throw new InvalidUser("fdfdfd");
            }
            _context.Vehicles.Remove(vehicle);
            _context.VehicleDetails.Remove(vehicledetail);
            return _context.SaveChanges();
        }

        public VehicleDTO GetVehicle(int userId)
        {
            Vehicle vehicle = _context.Vehicles.FirstOrDefault(v => v.BelongsToUserId == userId);
            VehicleDetail vehicleDetail;
            if (vehicle != null)
            {
                vehicleDetail = _context.VehicleDetails.FirstOrDefault(v => v.RegistrationNo==vehicle.RegistrationNo);

            }
            else
            {
                return new VehicleDTO();
            }
            VehicleDTO vehicleDTO = _mapper.Map<VehicleDTO>(vehicleDetail);
            vehicleDTO.BelongsToUserId = userId;
            vehicleDTO.VehicleTypeId = vehicle.VehicleTypeId;
            vehicleDTO.InspectionStatus = vehicle.InspectionStatus;
            vehicleDTO.VehicleType = _context.VehicleTypes.FirstOrDefault(v => v.ID == vehicleDTO.VehicleTypeId);
            return vehicleDTO;

        }

        public bool UpdateVehicleStatus(UpdateVehiceDTO updateVehiceDTO)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(v => v.RegistrationNo == updateVehiceDTO.RegistrationNo);
            vehicle.InspectionStatus= updateVehiceDTO.InspectionStatus;
            int r =_context.SaveChanges();
            if (r > 0)
            {
                return true;
            }
            return false;
        }


    }

}
