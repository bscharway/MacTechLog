using Microsoft.EntityFrameworkCore;
using PilotEntryService.Models.Entities;
using System.Collections.Generic;

namespace PilotEntryService.Data
{
    /// <summary>
    /// Entity Framework Context for the Pilot Entry Service.
    /// </summary>
    public class PilotEntryContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PilotEntryContext"/> class.
        /// </summary>
        /// <param name="options">The options to configure the context.</param>
        public PilotEntryContext(DbContextOptions<PilotEntryContext> options) : base(options)
        {
        }

        public DbSet<TripLog> TripLogs { get; set; }
        public DbSet<De_Anti_IcingData> DeAntiIcingData { get; set; }
        //public DbSet<FuelData> FuelData { get; set; }
        //public DbSet<Inspection> Inspections { get; set; }

        /// <summary>
        /// Configures the model and seeds initial data.
        /// </summary>
        /// <param name="modelBuilder">The builder used to construct the model.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for DeAntiIcingData
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

            //// Seed data for FuelData
            //modelBuilder.Entity<FuelData>().HasData(
            //    new FuelData
            //    {
            //        Id = 1,
            //        ParkingFuel = 1000,
            //        RevisedParkingFuel = 950,
            //        PlannedUplift = 500,
            //        ActualUplift = 480,
            //        FuelOnBoard = 1500,
            //        UpliftInLiters = 600
            //    },
            //    new FuelData
            //    {
            //        Id = 2,
            //        ParkingFuel = 1000,
            //        RevisedParkingFuel = 950,
            //        PlannedUplift = 500,
            //        ActualUplift = 480,
            //        FuelOnBoard = 1500,
            //        UpliftInLiters = 600
            //    }
            //);

            //// Seed data for Inspection
            //modelBuilder.Entity<Inspection>().HasData(
            //    new Inspection
            //    {
            //        Id = 1,
            //        PreFlightInspectionCompleted = true,
            //        PostFlightInspectionCompleted = true
            //    },
            //    new Inspection
            //    {
            //        Id = 2,
            //        PreFlightInspectionCompleted = true,
            //        PostFlightInspectionCompleted = true
            //    }
            //);

            // Seed data for TripLog
            modelBuilder.Entity<TripLog>().HasData(
                new TripLog
                {
                    Id = 1,
                    FlightNumber = "AB123",
                    AircraftRegistration = "N12345",
                    PilotId = "P001",
                    OffBlockTime = DateTime.UtcNow.AddHours(-5),
                    ActualTimeOfDeparture = (DateTime.UtcNow.AddHours(-5)).AddMinutes(5),
                    ActualTimeOfLanding = DateTime.UtcNow.AddMinutes(-5),
                    OnBlockTime = DateTime.UtcNow,
                    DepartureAirport = "JFK",
                    DestinationAirport = "LAX",
                    ParkingFuel = 1000,
                    RevisedParkingFuel = 950,
                    PlannedUplift = 500,
                    ActualUplift = 480,
                    FuelOnBoard = 1500,
                    UpliftInLiters = 600,
                    landingfuel = 800,
                    Remarks = "Smooth flight",
                    PreFlightInspectionCompleted = true,
                    PostFlightInspectionCompleted = true,
                    Cycles = 1,
                    DeAntiIcingDataId = 1,
                    
                    
                },
                new TripLog
                {
                    Id = 2,
                    FlightNumber = "AB124",
                    AircraftRegistration = "N12345",
                    PilotId = "P002",
                    OffBlockTime = DateTime.UtcNow.AddHours(-10),
                    ActualTimeOfDeparture = (DateTime.UtcNow.AddHours(-10)).AddMinutes(5),
                    ActualTimeOfLanding = (DateTime.UtcNow.AddHours(-5)).AddMinutes(-5),
                    OnBlockTime = DateTime.UtcNow.AddHours(-5),
                    DepartureAirport = "BLL",
                    DestinationAirport = "NVI",
                    ParkingFuel = 1000,
                    RevisedParkingFuel = 950,
                    PlannedUplift = 500,
                    ActualUplift = 480,
                    FuelOnBoard = 1500,
                    UpliftInLiters = 600,
                    landingfuel = 700,
                    Remarks = "Kinda bumpy",                    
                    PreFlightInspectionCompleted = true,
                    PostFlightInspectionCompleted = true,
                    Cycles = 1,
                    DeAntiIcingDataId = 2,
                }
            );
        }
    }
}
