using Microsoft.EntityFrameworkCore;
using PilotEntryService.Models.Entities;
using System.Collections.Generic;

namespace PilotEntryService.Data
{
    // Entity Framework Context
    public class PilotEntryContext : DbContext
    {
        public PilotEntryContext(DbContextOptions<PilotEntryContext> options) : base(options)
        {
        }

        public DbSet<TripLog> TripLogs { get; set; }
        public DbSet<De_Anti_IcingData> DeAntiIcingData { get; set; }
        public DbSet<FuelData> FuelData { get; set; }
        public DbSet<Inspection> Inspections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<De_Anti_IcingData>().HasData(
                new De_Anti_IcingData
                {
                    Id = 1,
                    FluidType = (int)FluideType.Type1,
                    MixtureRatio = "50/50",
                    Time = TimeOnly.FromDateTime(DateTime.UtcNow.AddHours(-4))
                },
               new De_Anti_IcingData
                {
                    Id = 2,
                    FluidType = (int)FluideType.Type2,
                    MixtureRatio = "50/50",
                    Time = TimeOnly.FromDateTime(DateTime.UtcNow.AddHours(-9))
                }
            );

            modelBuilder.Entity<FuelData>().HasData(
                new FuelData
                {
                    Id = 1,
                    ParkingFuel = 1000,
                    RevisedParkingFuel = 950,
                    PlannedUplift = 500,
                    ActualUplift = 480,
                    FuelOnBoard = 1500,
                    UpliftInLiters = 600
                },
                new FuelData
                {
                    Id = 2,
                    ParkingFuel = 1000,
                    RevisedParkingFuel = 950,
                    PlannedUplift = 500,
                    ActualUplift = 480,
                    FuelOnBoard = 1500,
                    UpliftInLiters = 600
                }
            );

            modelBuilder.Entity<Inspection>().HasData(
                new Inspection
                {
                    Id = 1,
                    PreFlightInspectionCompleted = true,
                    PostFlightInspectionCompleted = true
                },
                new Inspection
                {
                    Id = 2,
                    PreFlightInspectionCompleted = true,
                    PostFlightInspectionCompleted = true
                }
            );

            modelBuilder.Entity<TripLog>().HasData(
                new TripLog
                {
                    Id = 1,
                    FlightNumber = "AB123",
                    AircraftRegistration = "N12345",
                    PilotId = "P001",
                    DepartureTime = DateTime.UtcNow.AddHours(-5),
                    ArrivalTime = DateTime.UtcNow,
                    DepartureAirport = "JFK",
                    DestinationAirport = "LAX",
                    Remarks = "Smooth flight",
                    DeAntiIcingDataId = 1,
                    FuelDataId = 1,
                    InspectionId = 1
                },

                new TripLog
                {
                    Id = 2,
                    FlightNumber = "AB124",
                    AircraftRegistration = "N12345",
                    PilotId = "P002",
                    DepartureTime = DateTime.UtcNow.AddHours(-10),
                    ArrivalTime = DateTime.UtcNow.AddHours(-5),
                    DepartureAirport = "BLL",
                    DestinationAirport = "NVI",
                    Remarks = "kinda bumpy",
                    DeAntiIcingDataId = 2,
                    FuelDataId = 2, 
                    InspectionId = 2
                      
                }
            );
        }
    }
}
