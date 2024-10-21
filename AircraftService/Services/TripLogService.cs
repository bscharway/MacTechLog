namespace AircraftService.Services
{
    public class TripLogService
    {
        private readonly IAircraftService _aircraftService;

        public TripLogService(IAircraftService aircraftService)
        {
            _aircraftService = aircraftService;
        }

        public async Task LogCompletedTrip(int aircraftId, int flightHours, int cycles)
        {
            // Log trip details...

            // Update Aircraft flight hours and cycles
            await _aircraftService.UpdateFlightHoursAndCyclesAsync(aircraftId, flightHours, cycles);
        }
    }
}
