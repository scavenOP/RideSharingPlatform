using RideSharingPlatform.Microservices.VehicleManagement.Models;
using RideSharingPlatform.Microservices.VehicleManagement.Models.DTOs;

namespace RideSharingPlatform.Microservices.VehicleManagement.DAL.Interfaces
{
    public interface IVehicleRepository
    {
        List<VehicleType> GetVehicleTypes();
        int InsertVehicle(RegisterVehicleDTO registerVehicleDTO);
        int DeleteVehicle(string registtrationNo, int userid);
        VehicleDTO GetVehicle(int userId);
        bool UpdateVehicleStatus(UpdateVehiceDTO updateVehiceDTO);
        List<VehicleDTO> GetPendingVehicles();
    }
}
