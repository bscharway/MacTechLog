namespace AircraftService.Services
{
    public class TripLogService : ITripLogService
    {
        private readonly IAircraftService _aircraftService;

        public TripLogService(IAircraftService aircraftService)
        {
            _aircraftService = aircraftService;
        }

        public async Task LogCompletedTrip(string aircraftRegistration, int flightHours, int cycles)
        {
            // Log trip details...

            // Update Aircraft flight hours and cycles
            await _aircraftService.UpdateFlightHoursAndCyclesAsync(aircraftRegistration, flightHours, cycles);
        }
    }
}
