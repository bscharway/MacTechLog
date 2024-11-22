using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AircraftService.Models.Entities
{
    // Entity representing fuel management data
    public class FuelManagementData
    {
        public int Id { get; set; }
        public double LatestRecordedFuelOnBoard { get; set; } // Current fuel onboard in liters
        public double? RevisedParkingFuel { get; set; }
        public double PlannedUplift { get; set; } // Planned uplift in liters
        public double? ActualUplift { get; set; }
        public double? UpliftInLiters { get; set; }
        public double? LandingFuel { get; set; }
        public int? TripLogId { get; set; }
        public int? MaintenanceLogId { get; set; }

        [Required]
        [ForeignKey("Aircraft")]
        public string AircraftRegistration { get; set; }
        public Aircraft Aircraft { get; set; }


    }
}
