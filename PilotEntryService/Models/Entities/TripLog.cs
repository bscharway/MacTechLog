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
        public DateTime OffBlockTime { get; set; }
        public DateTime ActualTimeOfDeparture { get; set; }
        public DateTime ActualTimeOfLanding { get; set; }
        public DateTime OnBlockTime { get; set; }

        [MaxLength(4)]
        public string? DepartureAirport { get; set; }  
        [MaxLength(4)]
        public string DestinationAirport { get; set; }
        public double ParkingFuel { get; set; }
        public double? RevisedParkingFuel { get; set; }
        public double? PlannedUplift { get; set; }
        public double? ActualUplift { get; set; }
        public double? FuelOnBoard { get; set; }
        public double? UpliftInLiters { get; set; }
        public double? landingfuel { get; set; }

        // Computed Property for Fuel Consumption
        public double? FuelConsumption => (FuelOnBoard ?? 0) - landingfuel;

        public string? Remarks { get; set; }
        public int Cycles { get; set; }
        public bool PreFlightInspectionCompleted { get; set; }
        public bool PostFlightInspectionCompleted { get; set; }

        // Foreign keys and navigation properties
        public int? DeAntiIcingDataId { get; set; }
        public De_Anti_IcingData? DeAntiIcingData { get; set; }

        //public int FuelDataId { get; set; }
        //public FuelData FuelData { get; set; }

        //public int InspectionId { get; set; }
        //public Inspection Inspection { get; set; }
    }

}
