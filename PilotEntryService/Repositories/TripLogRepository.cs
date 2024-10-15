using Microsoft.EntityFrameworkCore;
using PilotEntryService.Data;
using PilotEntryService.Models.Entities;
using PilotEntryService.Repositories.Interfaces;

namespace PilotEntryService.Repositories
{
    // Repository Implementation
    public class TripLogRepository : ITripLogRepository
    {
        private readonly PilotEntryContext _context;

        public TripLogRepository(PilotEntryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TripLog>> GetAllTripLogsAsync()
        {
            return await _context.TripLogs
                .Include(t => t.DeAntiIcingData)
                .Include(t => t.FuelData)
                .Include(t => t.Inspection)
                .ToListAsync();
        }

        public async Task<TripLog> GetTripLogByIdAsync(int id)
        {
            return await _context.TripLogs
                .Include(t => t.DeAntiIcingData)
                .Include(t => t.FuelData)
                .Include(t => t.Inspection)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddTripLogAsync(TripLog tripLog)
        {
            await _context.TripLogs.AddAsync(tripLog);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTripLogAsync(TripLog tripLog)
        {
            _context.TripLogs.Update(tripLog);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTripLogAsync(int id)
        {
            var tripLog = await _context.TripLogs.FindAsync(id);
            if (tripLog != null)
            {
                _context.TripLogs.Remove(tripLog);
                await _context.SaveChangesAsync();
            }
        }
    }
}
