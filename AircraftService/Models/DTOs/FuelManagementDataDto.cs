namespace AircraftService.Models.DTOs
{
    // DTO for fuel management data
    public class FuelManagementDataDto
    {
        public double LatestRecordedFuelOnBoard { get; set; }
        public double? RevisedParkingFuel { get; set; }
        public double PlannedUplift { get; set; } // Planned uplift in liters
        public double? ActualUplift { get; set; }
        public double? UpliftInLiters { get; set; }
        public double LandingFuel { get; set; }
        public int AircraftId { get; set; }
    }
}
