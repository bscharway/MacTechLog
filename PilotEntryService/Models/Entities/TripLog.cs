using System.ComponentModel.DataAnnotations;

namespace PilotEntryService.Models.Entities
{
    /// <summary>
    /// Represents a trip log entity containing flight details.
    /// </summary>
    public class TripLog
    {
        public int Id { get; set; }
        [MaxLength(10)]
        [Required]
        public string FlightNumber { get; set; }
        [Required]
        public string AircraftRegistration { get; set; }  
        public string PilotId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        [MaxLength(4)]
        public string? DepartureAirport { get; set; }  
        [MaxLength(4)]
        public string DestinationAirport { get; set; }  
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
