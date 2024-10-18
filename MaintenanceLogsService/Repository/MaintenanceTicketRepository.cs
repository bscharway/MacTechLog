using MaintenanceLogsService.Data;
using MaintenanceLogsService.Models.Entities;
using MaintenanceLogsService.Repository;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceLogsService.Repositories
{
    // Repository Implementation for MaintenanceTicket
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

        public async Task UpdateMaintenanceTicketAsync(MaintenanceTicket maintenanceTicket)
        {
            _context.MaintenanceTickets.Update(maintenanceTicket);
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

        public async Task<List<MaintenanceTicket>> GetMaintenanceTicketsByIdsAsync(IEnumerable<int> ids)
        {
            return await _context.MaintenanceTickets.Where(t => ids.Contains(t.Id)).ToListAsync();
        }

        public async Task UpdateMaintenanceTicketsAsync(IEnumerable<MaintenanceTicket> tickets)
        {
            _context.MaintenanceTickets.UpdateRange(tickets);
            await _context.SaveChangesAsync();
        }
    }
}
