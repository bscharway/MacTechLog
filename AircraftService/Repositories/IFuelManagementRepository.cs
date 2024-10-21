using AircraftService.Models.Entities;

namespace AircraftService.Repositories
{
    public interface IFuelManagementRepository
    {
        Task AddFuelManagementDataAsync(FuelManagementData fuelManagementData);
        Task DeleteFuelManagementDataAsync(int id);
        Task<FuelManagementData> GetFuelManagementDataByIdAsync(int id);
        Task UpdateFuelManagementDataAsync(FuelManagementData fuelManagementData);
    }
}