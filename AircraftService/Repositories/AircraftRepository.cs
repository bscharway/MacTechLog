using AircraftService.Data;
using AircraftService.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AircraftService.Repositories
{
    // Aircraft Repository Implementation
    public class AircraftRepository : IAircraftRepository
    {
        private readonly AircraftDbContext _context;

        public AircraftRepository(AircraftDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Aircraft>> GetAllAircraftsAsync()
        {
            return await _context.Aircrafts
                .ToListAsync();
        }
        //public async Task<IEnumerable<Aircraft>> GetAllAircraftsAsync()
        //{
        //    return await _context.Aircrafts
        //        .Include(a => a.FuelManagementData) // Include related FuelManagementData
        //        .ToListAsync();
        //}

        public async Task<Aircraft> GetAircraftByIdAsync(string id)
        {
            return await _context.Aircrafts
                .FirstOrDefaultAsync(a => a.Registration == id);
        }
        //public async Task<Aircraft> GetAircraftByIdAsync(int id)
        //{
        //    return await _context.Aircrafts
        //        .Include(a => a.FuelManagementData) // Include related FuelManagementData
        //        .FirstOrDefaultAsync(a => a.Id == id);
        //}

        public async Task AddAircraftAsync(Aircraft aircraft)
        {
            await _context.Aircrafts.AddAsync(aircraft);
            await _context.SaveChangesAsync();
        }
        //public async Task AddAircraftAsync(Aircraft aircraft)
        //{
        //    if (aircraft.FuelManagementData != null)
        //    {
        //        await _context.FuelManagementData.AddAsync(aircraft.FuelManagementData);
        //    }

        //    await _context.Aircrafts.AddAsync(aircraft);
        //    await _context.SaveChangesAsync();
        //}

        public async Task UpdateAircraftAsync(Aircraft aircraft)
        {
            _context.Aircrafts.Update(aircraft);
            await _context.SaveChangesAsync();
        }
        //public async Task UpdateAircraftAsync(Aircraft aircraft)
        //{
        //    if (aircraft.FuelManagementData != null)
        //    {
        //        _context.FuelManagementData.Update(aircraft.FuelManagementData);
        //    }

        //    _context.Aircrafts.Update(aircraft);
        //    await _context.SaveChangesAsync();
        //}

        public async Task DeleteAircraftAsync(string id)
        {
            //var ac = await _context.Aircrafts.FirstOrDefaultAsync(a => a.Registration == id);
            // Delete related fuel management data
            var fuelManagementData = await _context.FuelManagementData.FirstOrDefaultAsync(f => f.AircraftRegistration == id);
            if (fuelManagementData != null)
            {
                _context.FuelManagementData.Remove(fuelManagementData);
            }

            var aircraft = await _context.Aircrafts.FindAsync(id);
            if (aircraft != null)
            {
                _context.Aircrafts.Remove(aircraft);
                await _context.SaveChangesAsync();
            }
        }
        //public async Task DeleteAircraftAsync(int id)
        //{
        //    var aircraft = await _context.Aircrafts
        //        .Include(a => a.FuelManagementData) // Ensure FuelManagementData is loaded
        //        .FirstOrDefaultAsync(a => a.Id == id);

        //    if (aircraft != null)
        //    {
        //        if (aircraft.FuelManagementData != null)
        //        {
        //            _context.FuelManagementData.Remove(aircraft.FuelManagementData);
        //        }
        //        _context.Aircrafts.Remove(aircraft);
        //        await _context.SaveChangesAsync();
        //    }
        //}
    }
}
