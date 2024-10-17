using System.ComponentModel.DataAnnotations;

namespace PilotEntryService.Models.DTOs
{

    /// <summary>
    /// DTO for creating a new trip log (without Id).
    /// </summary>
    public class CreateTripLogDto
    {
        [Required]
        public string FlightNumber { get; set; }
        [Required]
        public string AircraftRegistration { get; set; }
        [Required]
        public string PilotId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string DepartureAirport { get; set; }
        public string DestinationAirport { get; set; }
        public string Remarks { get; set; }

        // Embedded additional data
        public CreateDe_Anti_IcingDataDto? DeAntiIcingData { get; set; }
        public CreateFuelDataDto FuelData { get; set; }
        public CreateInspectionDto Inspection { get; set; }
    }
}
