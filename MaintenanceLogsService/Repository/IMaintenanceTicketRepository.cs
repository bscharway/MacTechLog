using MaintenanceLogsService.Models.Entities;

namespace MaintenanceLogsService.Repository
{
    // Maintenance Ticket Repository Interface
    public interface IMaintenanceTicketRepository
    {
        Task AddMaintenanceTicketAsync(MaintenanceTicket ticket);
        Task UpdateMaintenanceTicketAsync(MaintenanceTicket ticket);
        Task<MaintenanceTicket> GetMaintenanceTicketByIdAsync(int id);
        Task<IEnumerable<MaintenanceTicket>> GetAllMaintenanceTicketsAsync();
    }
}
