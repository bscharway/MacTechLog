using MaintenanceLogsService.Data;
using MaintenanceLogsService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceLogsService.Repository
{
    // Maintenance Ticket Repository Implementation
    public class MaintenanceTicketRepository : IMaintenanceTicketRepository
    {
        private readonly MaintenanceLogsContext _context;

        public MaintenanceTicketRepository(MaintenanceLogsContext context)
        {
            _context = context;
        }

        public async Task AddMaintenanceTicketAsync(MaintenanceTicket ticket)
        {
            await _context.MaintenanceTickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMaintenanceTicketAsync(MaintenanceTicket ticket)
        {
            _context.MaintenanceTickets.Update(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task<MaintenanceTicket> GetMaintenanceTicketByIdAsync(int id)
        {
            return await _context.MaintenanceTickets.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<MaintenanceTicket>> GetAllMaintenanceTicketsAsync()
        {
            return await _context.MaintenanceTickets.ToListAsync();
        }
    }
}
