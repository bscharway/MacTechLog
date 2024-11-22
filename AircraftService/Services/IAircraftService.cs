using AircraftService.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AircraftService.Services
{
    // Aircraft Service Interface
    public interface IAircraftService
    {
        Task<IEnumerable<AircraftDto>> GetAllAircraftAsync();
        Task<AircraftDto> GetAircraftByIdAsync(string aircraftRegistration);
        Task<AircraftDto> AddAircraftAsync(CreateAircraftDto createAircraftDto);
        Task UpdateAircraftAsync(string aircraftRegistration, UpdateAircraftDto updateAircraftDto);
        Task DeleteAircraftAsync(string aircraftRegistration);
        Task UpdateFuelManagementAsync(string aircraftRegistration, UpdateFuelManagementDto fuelManagementDto);
        Task UpdateFlightHoursAndCyclesAsync(string aircraftId, int additionalHours, int additionalCycles);

        // Method for updating flight hours, cycles, and fuel
        Task UpdateFlightHoursCyclesAndFuelAsync(string aircraftRegistration, int flightHours, int cycles, double fuelConsumed);
        Task UpdateFlightHoursCyclesAndFuelAsyncFromMessageBroker(string aircraftRegistration, int flightHours, int cycles, double landingFuel, int tripLogId = 0, int maintenanceLogId = 0);
    }
}
