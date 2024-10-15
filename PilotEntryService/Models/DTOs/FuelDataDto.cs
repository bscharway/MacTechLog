namespace PilotEntryService.Models.DTOs
{
    public class FuelDataDto
    {
        public int Id { get; set; }
        public double ParkingFuel { get; set; }
        public double RevisedParkingFuel { get; set; }
        public double PlannedUplift { get; set; }
        public double ActualUplift { get; set; }
        public double FuelOnBoard { get; set; }
        public double UpliftInLiters { get; set; }
    }
}
