using AircraftService.Models.DTOs;

namespace AircraftService.Services
{
    public interface IFuelManagementService
    {
        Task<IEnumerable<FuelManagementDataDto>> GetAllFuelManagementDataAsync();
        Task<FuelManagementDataDto> GetFuelManagementDataByIdAsync(int id);
        Task AddFuelManagementDataAsync(FuelManagementDataDto fuelManagementDataDto);
        Task UpdateFuelManagementDataAsync(int id, FuelManagementDataDto fuelManagementDataDto);
        Task DeleteFuelManagementDataAsync(int id);
    }
}
