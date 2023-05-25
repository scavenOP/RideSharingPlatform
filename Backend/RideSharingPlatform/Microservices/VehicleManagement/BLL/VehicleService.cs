using AutoMapper;
using RideSharingPlatform.Context;
using RideSharingPlatform.Microservices.VehicleManagement.BLL.Exceptions;
using RideSharingPlatform.Microservices.VehicleManagement.DAL;
using RideSharingPlatform.Microservices.VehicleManagement.DAL.Interfaces;
using RideSharingPlatform.Microservices.VehicleManagement.Models;
using RideSharingPlatform.Microservices.VehicleManagement.Models.DTOs;
using System.Text.RegularExpressions;

namespace RideSharingPlatform.Microservices.VehicleManagement.BLL
{
    public class VehicleService
    {
        private IVehicleRepository _vehicleRepository;
        private RideDbContext _context;
        private IMapper _mapper;

        public VehicleService(RideDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _vehicleRepository = new VehcileRepository(_context,_mapper);
        }

        public List<VehicleType> GetAllVehicleTypes()
        {
            return _vehicleRepository.GetVehicleTypes();
        }

        public bool insertVehicle(RegisterVehicleDTO registerVehicleDTO)
        {
            if (registerVehicleDTO.RegistrationNo.Length != 10)
            {
                throw new InvalidRegistrationNoException("Registration number must be 10");
            }
            Regex regex = new Regex("^[A-Za-z]{2}\\d{2}[A-Za-z]{2}\\d{4}$");
            if (!regex.IsMatch(registerVehicleDTO.RegistrationNo))
            {
                throw new InvalidRegistrationNoException("Invalid Registration No format");
            }
            if (DateTime.Now.Year - registerVehicleDTO.RegistrationDate.Year > 15)
            {
                throw new InvalidRegistrationNoException("Vehicle is more than 15 years old");

            }
            if (registerVehicleDTO.InsuranceExpiresOn.Year - DateTime.Now.Year < 1)
            {
                throw new InvalidRegistrationNoException("Insurence Expiry date is less than 1 year");
            }
            int monthsApart = 12 * (DateTime.Now.Year - registerVehicleDTO.PUCValidUntil.Year) + DateTime.Now.Month - registerVehicleDTO.PUCValidUntil.Month;
            if (monthsApart > 6)
            {
                throw new InvalidRegistrationNoException("PUC Expiry date is less than 6 months"+monthsApart.ToString());
            }

            int r = _vehicleRepository.InsertVehicle(registerVehicleDTO);
            if(r > 0)
            {
                return true;
            }
            return false;
        }
        public bool deletevehicle(string vehicleregno, int userid)
        {
            int r = _vehicleRepository.DeleteVehicle(vehicleregno, userid);
            if(r > 0)
            {
                return true;
            }
            return false;
        }

        public VehicleDTO Getvehiclebyuserid(int userid)
        {
            return _vehicleRepository.GetVehicle(userid);
        }

        public List<VehicleDTO> GetAllPendingVehicles() { 
            return _vehicleRepository.GetPendingVehicles();
        
        }

        public bool UpdateVehicleStatus(UpdateVehiceDTO updateVehiceDTO)
        {
            return _vehicleRepository.UpdateVehicleStatus(updateVehiceDTO);
        }
    }
}
