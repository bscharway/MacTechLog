
namespace AircraftService.Services
{
    public interface ITripLogService
    {
        Task LogCompletedTrip(string aircraftRegistration, int flightHours, int cycles);
    }
}