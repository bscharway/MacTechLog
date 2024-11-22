using AircraftService.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AircraftService.Data
{
    public class AircraftDbContext : DbContext
    {
        public AircraftDbContext(DbContextOptions<AircraftDbContext> options) : base(options)
        {
        }

        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<FuelManagementData> FuelManagementData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Aircraft>().HasData(
                new Aircraft
                {
                    //Id = 1,
                    Registration = "N12345",
                    Model = "Boeing 737",
                    
                    CurrentStatus = "Airworthy",
                    TotalFlightHours = 5000,
                    Cycles = 1500,
                    LastUpdated = DateTime.UtcNow,
                    //FuelManagementDataId = 1
                },
                new Aircraft
                {
                    //Id = 2,
                    Registration = "G67890",
                    Model = "Airbus A320",
                    
                    CurrentStatus = "AOG",
                    TotalFlightHours = 4000,
                    Cycles = 1200,
                    LastUpdated = DateTime.UtcNow,
                    //FuelManagementDataId = 2
                },
                new Aircraft
                {
                    //Id = 3,
                    Registration = "D45678",
                    Model = "Boeing 747",
                    
                    CurrentStatus = "Airworthy",
                    TotalFlightHours = 10000,
                    Cycles = 3000,
                    LastUpdated = DateTime.UtcNow,
                    //FuelManagementDataId = 3
                },
                new Aircraft
                {
                    //Id = 4,
                    Registration = "F12367",
                    Model = "Airbus A380",
                    
                    CurrentStatus = "Under Maintenance",
                    TotalFlightHours = 7000,
                    Cycles = 2000,
                    LastUpdated = DateTime.UtcNow,
                    //FuelManagementDataId = 4
                },
                new Aircraft
                {
                    //Id = 5,
                    Registration = "H89012",
                    Model = "Embraer E190",
                    CurrentStatus = "Airworthy",
                    TotalFlightHours = 2000,
                    Cycles = 800,
                    LastUpdated = DateTime.UtcNow,
                    //FuelManagementDataId = 5
                },
                new Aircraft
                {
                    //Id = 6,
                    Registration = "I34567",
                    Model = "Cessna 172",
                    
                    CurrentStatus = "Airworthy",
                    TotalFlightHours = 500,
                    Cycles = 300,
                    LastUpdated = DateTime.UtcNow,
                    //FuelManagementDataId = 6
                }
            );

            modelBuilder.Entity<FuelManagementData>().HasData(
                new FuelManagementData
                {
                    Id = 1,
                    LatestRecordedFuelOnBoard = 15000,
                    RevisedParkingFuel = 15000,
                    PlannedUplift = 5000,
                    ActualUplift = 5000,
                    UpliftInLiters = 2700,
                    LandingFuel = 10000,
                    AircraftRegistration = "N12345"
                },
                new FuelManagementData
                {
                    Id = 2,
                    LatestRecordedFuelOnBoard = 12000,
                    RevisedParkingFuel = 12000,
                    PlannedUplift = 3000,
                    ActualUplift = 3100,
                    UpliftInLiters = 1500,
                    LandingFuel = 6000,
                    AircraftRegistration = "G67890"
                },
                new FuelManagementData
                {
                    Id = 3,
                    LatestRecordedFuelOnBoard = 20000,
                    RevisedParkingFuel = 19500,
                    PlannedUplift = 30000,
                    ActualUplift = 30100,
                    UpliftInLiters = 15000,
                    LandingFuel = 30000,
                    AircraftRegistration = "D45678"
                },
                new FuelManagementData
                {
                    Id = 4,
                    LatestRecordedFuelOnBoard = 25000,
                    RevisedParkingFuel = 24500,
                    PlannedUplift = 20000,
                    ActualUplift = 21000,
                    UpliftInLiters = 22000,
                    LandingFuel = 30000,
                    AircraftRegistration = "F12367"
                },
                new FuelManagementData
                {
                    Id = 5,
                    LatestRecordedFuelOnBoard = 5000,
                    RevisedParkingFuel = 5000,
                    PlannedUplift = 2000,
                    ActualUplift = 2100,
                    UpliftInLiters = 3200,
                    LandingFuel = 3400,
                    AircraftRegistration = "H89012"
                },
                new FuelManagementData
                {
                    Id = 6,
                    LatestRecordedFuelOnBoard = 52000,
                    RevisedParkingFuel = 52000,
                    PlannedUplift = 22000,
                    ActualUplift = 22100,
                    UpliftInLiters = 32200,
                    LandingFuel = 32400,
                    AircraftRegistration = "I34567"
                }
            );
        }
    }
}
