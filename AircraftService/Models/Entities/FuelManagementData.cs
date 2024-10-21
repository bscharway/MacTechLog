namespace AircraftService.Models.Entities
{
    // Entity representing fuel management data
    public class FuelManagementData
    {
        public int Id { get; set; }
        public double FuelOnBoard { get; set; } // Current fuel onboard in liters
        public double RecentUplift { get; set; } // Recently added fuel in liters
        public double PlannedUplift { get; set; } // Planned uplift in liters
        public DateTime LastRefueled { get; set; } // Timestamp of the last refueling
        public int FuelCapacity { get; set; } 
    }
}
