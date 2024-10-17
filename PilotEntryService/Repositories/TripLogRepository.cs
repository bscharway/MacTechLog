using Microsoft.EntityFrameworkCore;
using PilotEntryService.Data;
using PilotEntryService.Models.Entities;
using PilotEntryService.Repositories.Interfaces;

namespace PilotEntryService.Repositories
{
    /// <summary>
    /// Repository implementation for managing TripLog entities.
    /// </summary>
    public class TripLogRepository : ITripLogRepository
    {
        private readonly PilotEntryContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TripLogRepository"/> class.
        /// </summary>
        /// <param name="context">The database context for Pilot Entry Service.</param>
        public TripLogRepository(PilotEntryContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all TripLogs asynchronously.
        /// </summary>
        /// <returns>A list of all TripLogs.</returns>
        public async Task<IEnumerable<TripLog>> GetAllTripLogsAsync()
        {
            return await _context.TripLogs
                .Include(t => t.DeAntiIcingData)
                .Include(t => t.FuelData)
                .Include(t => t.Inspection)
                .ToListAsync();
        }

        /// <summary>
        /// Gets a specific TripLog by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the TripLog.</param>
        /// <returns>The TripLog with the specified ID.</returns>
        public async Task<TripLog> GetTripLogByIdAsync(int id)
        {
            return await _context.TripLogs
                .Include(t => t.DeAntiIcingData)
                .Include(t => t.FuelData)
                .Include(t => t.Inspection)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        /// <summary>
        /// Adds a new TripLog asynchronously.
        /// </summary>
        /// <param name="tripLog">The TripLog to add.</param>
        public async Task AddTripLogAsync(TripLog tripLog)
        {
            await _context.TripLogs.AddAsync(tripLog);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing TripLog asynchronously.
        /// </summary>
        /// <param name="tripLog">The TripLog to update.</param>
        public async Task UpdateTripLogAsync(TripLog tripLog)
        {
            _context.TripLogs.Update(tripLog);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a TripLog by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the TripLog to delete.</param>
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
