namespace AircraftService.Models.DTOs
{
    public class CreateUpdateAircraftDto
    {
        public string Registration { get; set; }
        public string Model { get; set; }
        public double FuelCapacity { get; set; }
        public int TotalFlightHours { get; set; }
        public int Cycles { get; set; }
    }
}
