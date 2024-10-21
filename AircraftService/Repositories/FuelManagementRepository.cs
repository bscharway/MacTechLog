using AircraftService.Data;
using AircraftService.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AircraftService.Repositories
{
    // Fuel Management Repository Implementation
    public class FuelManagementRepository : IFuelManagementRepository
    {
        private readonly AircraftDbContext _context;

        public FuelManagementRepository(AircraftDbContext context)
        {
            _context = context;
        }

        public async Task<FuelManagementData> GetFuelManagementDataByIdAsync(int id)
        {
            return await _context.FuelManagementData
                .AsNoTracking() // Improve performance by not tracking the retrieved entity
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task AddFuelManagementDataAsync(FuelManagementData fuelManagementData)
        {
            // Ensure the Id is not set explicitly for a new entity
            fuelManagementData.Id = 0;
            await _context.FuelManagementData.AddAsync(fuelManagementData);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFuelManagementDataAsync(FuelManagementData fuelManagementData)
        {
            var existingFuelManagementData = await _context.FuelManagementData.FindAsync(fuelManagementData.Id);
            if (existingFuelManagementData != null)
            {
                _context.Entry(existingFuelManagementData).CurrentValues.SetValues(fuelManagementData);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteFuelManagementDataAsync(int id)
        {
            var fuelManagementData = await _context.FuelManagementData.FindAsync(id);
            if (fuelManagementData != null)
            {
                _context.FuelManagementData.Remove(fuelManagementData);
                await _context.SaveChangesAsync();
            }
        }
    }
}
