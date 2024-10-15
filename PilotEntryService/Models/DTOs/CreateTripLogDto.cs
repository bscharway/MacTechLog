namespace PilotEntryService.Models.DTOs
{
    // DTO for creating TripLog (without Id)
    public class CreateTripLogDto
    {
        public string FlightNumber { get; set; }
        public string AircraftRegistration { get; set; }
        public string PilotId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string DepartureAirport { get; set; }
        public string DestinationAirport { get; set; }
        public string Remarks { get; set; }

        // Embedded additional data
        public CreateDe_Anti_IcingDataDto DeAntiIcingData { get; set; }
        public CreateFuelDataDto FuelData { get; set; }
        public CreateInspectionDto Inspection { get; set; }
    }
}
