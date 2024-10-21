using MaintenanceLogsService.Models.DTOs;
using MaintenanceLogsService.Models.Entities;

namespace MaintenanceLogsService.Services
{
    // Service Interface
    public interface IMaintenanceLogService
    {
        Task<IEnumerable<MaintenanceLogDto>> GetAllMaintenanceLogsAsync();
        Task<MaintenanceLogDto> GetMaintenanceLogByIdAsync(int id);
        Task<MaintenanceLogDto> AddMaintenanceLogAsync(CreateMaintenanceLogDto maintenanceLogDto);
        Task UpdateMaintenanceLogAsync(int id, CreateMaintenanceLogDto maintenanceLogDto);
        Task DeleteMaintenanceLogAsync(int id);
        Task<MaintenanceTicketDto> AddMaintenanceTicketAsync(CreateMaintenanceTicketDto ticketDto);
        Task<MaintenanceTicketDto> UpdateMaintenanceTicketStatusAsync(int ticketId, string status);
        Task<IEnumerable<MaintenanceTicketDto>> GetAllTicketsAsync();
        Task<MaintenanceTicketDto> GetMaintenanceTicketByIdAsync(int id);
    }
}
