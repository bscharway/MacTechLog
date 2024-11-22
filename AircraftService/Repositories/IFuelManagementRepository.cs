using AircraftService.Models.Entities;

namespace AircraftService.Repositories
{
    public interface IFuelManagementRepository
    {
        Task AddFuelManagementDataAsync(FuelManagementData fuelManagementData);
        Task DeleteFuelManagementDataAsync(int id);
        Task<FuelManagementData> GetFuelManagementDataByIdAsync(int id);
        Task<FuelManagementData> GetFuelManagementDataByAircraftIdAsync(string aircraftId);
        Task UpdateFuelManagementDataAsync(FuelManagementData fuelManagementData);
        Task<IEnumerable<FuelManagementData>> GetAllFuelManagementDataAsync();
    }
}