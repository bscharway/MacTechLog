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
                    Id = 1,
                    Registration = "N12345",
                    Model = "Boeing 737",
                    
                    CurrentStatus = "Airworthy",
                    TotalFlightHours = 5000,
                    Cycles = 1500,
                    LastUpdated = DateTime.UtcNow,
                    FuelManagementDataId = 1
                },
                new Aircraft
                {
                    Id = 2,
                    Registration = "G67890",
                    Model = "Airbus A320",
                    
                    CurrentStatus = "AOG",
                    TotalFlightHours = 4000,
                    Cycles = 1200,
                    LastUpdated = DateTime.UtcNow,
                    FuelManagementDataId = 2
                },
                new Aircraft
                {
                    Id = 3,
                    Registration = "D45678",
                    Model = "Boeing 747",
                    
                    CurrentStatus = "Airworthy",
                    TotalFlightHours = 10000,
                    Cycles = 3000,
                    LastUpdated = DateTime.UtcNow,
                    FuelManagementDataId = 3
                },
                new Aircraft
                {
                    Id = 4,
                    Registration = "F12367",
                    Model = "Airbus A380",
                    
                    CurrentStatus = "Under Maintenance",
                    TotalFlightHours = 7000,
                    Cycles = 2000,
                    LastUpdated = DateTime.UtcNow,
                    FuelManagementDataId = 4
                },
                new Aircraft
                {
                    Id = 5,
                    Registration = "H89012",
                    Model = "Embraer E190",
                    CurrentStatus = "Airworthy",
                    TotalFlightHours = 2000,
                    Cycles = 800,
                    LastUpdated = DateTime.UtcNow,
                    FuelManagementDataId = 5
                },
                new Aircraft
                {
                    Id = 6,
                    Registration = "I34567",
                    Model = "Cessna 172",
                    
                    CurrentStatus = "Airworthy",
                    TotalFlightHours = 500,
                    Cycles = 300,
                    LastUpdated = DateTime.UtcNow,
                    FuelManagementDataId = 6
                }
            );

            modelBuilder.Entity<FuelManagementData>().HasData(
                new FuelManagementData
                {
                    Id = 1,
                    FuelCapacity = 26000,
                    FuelOnBoard = 15000,
                    RecentUplift = 5000,
                    PlannedUplift = 6000,
                    LastRefueled = DateTime.UtcNow.AddDays(-1)
                },
                new FuelManagementData
                {
                    Id = 2,
                    FuelCapacity = 24210,
                    FuelOnBoard = 12000,
                    RecentUplift = 3000,
                    PlannedUplift = 5000,
                    LastRefueled = DateTime.UtcNow.AddDays(-2)
                },
                new FuelManagementData
                {
                    Id = 3,
                    FuelCapacity = 183380,
                    FuelOnBoard = 80000,
                    RecentUplift = 50000,
                    PlannedUplift = 60000,
                    LastRefueled = DateTime.UtcNow.AddDays(-3)
                },
                new FuelManagementData
                {
                    Id = 4,
                    FuelCapacity = 320000,
                    FuelOnBoard = 250000,
                    RecentUplift = 70000,
                    PlannedUplift = 80000,
                    LastRefueled = DateTime.UtcNow.AddDays(-4)
                },
                new FuelManagementData
                {
                    Id = 5,
                    FuelCapacity = 13000,
                    FuelOnBoard = 8000,
                    RecentUplift = 3000,
                    PlannedUplift = 4000,
                    LastRefueled = DateTime.UtcNow.AddDays(-5)
                },
                new FuelManagementData
                {
                    Id = 6,
                    FuelCapacity = 210,
                    FuelOnBoard = 100,
                    RecentUplift = 50,
                    PlannedUplift = 70,
                    LastRefueled = DateTime.UtcNow.AddDays(-6)
                }
            );
        }
    }
}
