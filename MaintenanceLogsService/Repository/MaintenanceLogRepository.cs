using MaintenanceLogsService.Data;
using MaintenanceLogsService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceLogsService.Repository
{
    // Repository Implementation
    public class MaintenanceLogRepository : IMaintenanceLogRepository
    {
        private readonly MaintenanceLogsContext _context;

        public MaintenanceLogRepository(MaintenanceLogsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MaintenanceLog>> GetAllMaintenanceLogsAsync()
        {
            return await _context.MaintenanceLogs
                .Include(m => m.DefectReports)
                .Include(m => m.PartReplacements)
                .Include(m => m.OilHydraulicFluidData)
                .ToListAsync();
        }

        public async Task<MaintenanceLog> GetMaintenanceLogByIdAsync(int id)
        {
            return await _context.MaintenanceLogs
                .Include(m => m.DefectReports)
                .Include(m => m.PartReplacements)
                .Include(m => m.OilHydraulicFluidData)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddMaintenanceLogAsync(MaintenanceLog maintenanceLog)
        {
            await _context.MaintenanceLogs.AddAsync(maintenanceLog);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMaintenanceLogAsync(MaintenanceLog maintenanceLog)
        {
            _context.MaintenanceLogs.Update(maintenanceLog);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMaintenanceLogAsync(int id)
        {
            var maintenanceLog = await _context.MaintenanceLogs.FindAsync(id);
            if (maintenanceLog != null)
            {
                _context.MaintenanceLogs.Remove(maintenanceLog);
                await _context.SaveChangesAsync();
            }
        }
    }
}
