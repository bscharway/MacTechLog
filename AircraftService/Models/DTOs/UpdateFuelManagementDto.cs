namespace AircraftService.Models.DTOs
{
    // DTO for updating fuel management information
    public class UpdateFuelManagementDto
    {
        public double? RevisedParkingFuel { get; set; }
        public double PlannedUplift { get; set; } // Planned uplift in liters
        public double? ActualUplift { get; set; }
        public double? UpliftInLiters { get; set; }
        public double LandingFuel { get; set; }
    }
}
