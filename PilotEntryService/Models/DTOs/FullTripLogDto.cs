namespace PilotEntryService.Models.DTOs
{
    /// <summary>
    /// DTO for a full trip log.
    /// </summary>
    public class FullTripLogDto
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string AircraftRegistration { get; set; }
        public string PilotId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string DepartureAirport { get; set; }
        public string DestinationAirport { get; set; }
        public string Remarks { get; set; }

        // Embedded additional data
        public De_Anti_IcingDataDto DeAntiIcingData { get; set; }
        public FuelDataDto FuelData { get; set; }
        public InspectionDto Inspection { get; set; }
    }
}
