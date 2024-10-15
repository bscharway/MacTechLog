using System.ComponentModel.DataAnnotations;

namespace PilotEntryService.Models.Entities
{
    // Entity Model for TripLog
    public class TripLog
    {
        public int Id { get; set; }
        [MaxLength(10)]
        public string FlightNumber { get; set; }  // Added Flight Number
        public string AircraftRegistration { get; set; }  // Changed from AircraftId to AircraftRegistration
        public string PilotId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        [MaxLength(4)]
        public string? DepartureAirport { get; set; }  // Added max length for Departure Airport
        [MaxLength(4)]
        public string DestinationAirport { get; set; }  // Added max length for Destination Airport
        public string? Remarks { get; set; }

        // Foreign keys and navigation properties
        public int? DeAntiIcingDataId { get; set; }
        public De_Anti_IcingData? DeAntiIcingData { get; set; }

        public int FuelDataId { get; set; }
        public FuelData FuelData { get; set; }

        public int InspectionId { get; set; }
        public Inspection Inspection { get; set; }
    }

}
