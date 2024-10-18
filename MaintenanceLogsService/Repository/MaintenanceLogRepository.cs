using MaintenanceLogsService.Data;
using MaintenanceLogsService.Models.Entities;
using MaintenanceLogsService.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenanceLogsService.Repositories
{
    // Repository Implementation for MaintenanceLog
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
                .Select(m => new MaintenanceLog
                {
                    Id = m.Id,
                    AircraftRegistration = m.AircraftRegistration,
                    MaintenanceDate = m.MaintenanceDate,
                    TechnicianId = m.TechnicianId,
                    Description = m.Description,
                    // Include only the necessary fields
                })
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
