using PilotEntryService.Models.DTOs;

namespace PilotEntryService.Services.Interfaces
{
    // Service Interface
    public interface ITripLogService
    {
        Task<IEnumerable<FullTripLogDto>> GetAllTripLogsAsync();
        Task<FullTripLogDto> GetTripLogByIdAsync(int id);
        Task AddTripLogAsync(CreateTripLogDto tripLogDto);
        Task UpdateTripLogAsync(int id, CreateTripLogDto tripLogDto);
        Task DeleteTripLogAsync(int id);
    }
}
