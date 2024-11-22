using System.ComponentModel.DataAnnotations;

namespace PilotEntryService.Models.DTOs
{
    /// <summary>
    /// DTO for a full trip log.
    /// </summary>
    public class FullTripLogDto
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        [Required]
        public string AircraftRegistration { get; set; }
        [Required]
        public string PilotId { get; set; }
        public DateTime OffBlockTime { get; set; }
        public DateTime ActualTimeOfDeparture { get; set; }
        public DateTime ActualTimeOfLanding { get; set; }
        public DateTime OnBlockTime { get; set; }
        public string DepartureAirport { get; set; }
        public string DestinationAirport { get; set; }
        public double ParkingFuel { get; set; }
        public double? RevisedParkingFuel { get; set; }
        public double? PlannedUplift { get; set; }
        public double? ActualUplift { get; set; }
        public double? FuelOnBoard { get; set; }
        public double? UpliftInLiters { get; set; }
        public double landingfuel { get; set; }
        public string Remarks { get; set; }
        public int Cycles { get; set; }
        public bool PreFlightInspectionCompleted { get; set; }
        public bool PostFlightInspectionCompleted { get; set; }

        // Embedded additional data
        public De_Anti_IcingDataDto DeAntiIcingData { get; set; }
        //public FuelDataDto FuelData { get; set; }
        //public InspectionDto Inspection { get; set; }
    }
}
