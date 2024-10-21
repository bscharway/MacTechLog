namespace AircraftService.Models.DTOs
{
    // DTO for updating fuel management information
    public class UpdateFuelManagementDto
    {
        public double FuelOnBoard { get; set; }
        public double RecentUplift { get; set; }
        public double PlannedUplift { get; set; }
        public int FuelCapacity { get; set; } 
    }
}
