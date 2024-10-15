using MaintenanceLogsService.Models.DTOs;

namespace MaintenanceLogsService.Sevices
{
    // Service Interface
    public interface IMaintenanceLogService
    {
        Task<IEnumerable<MaintenanceLogDto>> GetAllMaintenanceLogsAsync();
        Task<MaintenanceLogDto> GetMaintenanceLogByIdAsync(int id);
        Task AddMaintenanceLogAsync(CreateMaintenanceLogDto maintenanceLogDto);
        Task UpdateMaintenanceLogAsync(int id, CreateMaintenanceLogDto maintenanceLogDto);
        Task DeleteMaintenanceLogAsync(int id);
    }
}
