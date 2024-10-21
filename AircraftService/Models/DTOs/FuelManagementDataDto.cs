namespace AircraftService.Models.DTOs
{
    // DTO for fuel management data
    public class FuelManagementDataDto
    {
        public double FuelOnBoard { get; set; }
        public double RecentUplift { get; set; }
        public double PlannedUplift { get; set; }
        public DateTime LastRefueled { get; set; }
        public int FuelCapacity { get; set; } // Add this property
    }
}
