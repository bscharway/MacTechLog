using System.ComponentModel.DataAnnotations;

namespace PilotEntryService.Models.Entities
{
    public class FuelData
    {
        public int Id { get; set; }
        [Required]
        public double ParkingFuel { get; set; }
        public double? RevisedParkingFuel { get; set; }
        public double? PlannedUplift { get; set; }
        public double? ActualUplift { get; set; }
        public double? FuelOnBoard { get; set; }
        public double? UpliftInLiters { get; set; }
    }
}
