using MaintenanceLogsService.Models.Entities;

namespace MaintenanceLogsService.Repository
{
    public interface IMaintenanceLogRepository
    {
        Task<IEnumerable<MaintenanceLog>> GetAllMaintenanceLogsAsync();
        Task<MaintenanceLog> GetMaintenanceLogByIdAsync(int id);
        Task AddMaintenanceLogAsync(MaintenanceLog maintenanceLog);
        Task UpdateMaintenanceLogAsync(MaintenanceLog maintenanceLog);
        Task DeleteMaintenanceLogAsync(int id);
    }
}
