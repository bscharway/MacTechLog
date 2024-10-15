using PilotEntryService.Models.DTOs;
using PilotEntryService.Models.Entities;

namespace PilotEntryService.Repositories.Interfaces
{
    // Repository Interface
    public interface ITripLogRepository
    {
        Task<IEnumerable<TripLog>> GetAllTripLogsAsync();
        Task<TripLog> GetTripLogByIdAsync(int id);
        Task AddTripLogAsync(TripLog tripLog);
        Task UpdateTripLogAsync(TripLog tripLog);
        Task DeleteTripLogAsync(int id);
    }
}