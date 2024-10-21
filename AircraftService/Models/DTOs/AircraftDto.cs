namespace AircraftService.Models.DTOs
{
    // DTO for returning aircraft information
    public class AircraftDto
    {
        public int Id { get; set; }
        public string Registration { get; set; }
        public string Model { get; set; }
        public double FuelCapacity { get; set; }
        public string CurrentStatus { get; set; }
        public DateTime LastUpdated { get; set; }
        public int TotalFlightHours { get; set; }
        public int Cycles { get; set; }
        public FuelManagementDataDto FuelManagement { get; set; }
    }
}
