using AircraftService.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AircraftService.Services
{
    // Aircraft Service Interface
    public interface IAircraftService
    {
        Task<IEnumerable<AircraftDto>> GetAllAircraftAsync();
        Task<AircraftDto> GetAircraftByIdAsync(int id);
        Task<AircraftDto> AddAircraftAsync(CreateAircraftDto createAircraftDto);
        Task UpdateAircraftAsync(int id, UpdateAircraftDto updateAircraftDto);
        Task DeleteAircraftAsync(int id);
        Task UpdateFuelManagementAsync(int id, UpdateFuelManagementDto fuelManagementDto);
        Task UpdateFlightHoursAndCyclesAsync(int aircraftId, int additionalHours, int additionalCycles);
    }
}
