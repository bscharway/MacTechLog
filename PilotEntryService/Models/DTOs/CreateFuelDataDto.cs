namespace PilotEntryService.Models.DTOs
{
    // DTO for creating FuelData (without Id)
    public class CreateFuelDataDto
    {
        public double ParkingFuel { get; set; }
        public double RevisedParkingFuel { get; set; }
        public double PlannedUplift { get; set; }
        public double ActualUplift { get; set; }
        public double FuelOnBoard { get; set; }
        public double UpliftInLiters { get; set; }
    }
}
