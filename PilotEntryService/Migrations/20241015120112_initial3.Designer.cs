﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PilotEntryService.Data;

#nullable disable

namespace PilotEntryService.Migrations
{
    [DbContext(typeof(PilotEntryContext))]
    [Migration("20241015120112_initial3")]
    partial class initial3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PilotEntryService.Models.Entities.De_Anti_IcingData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FluidType")
                        .HasColumnType("int");

                    b.Property<string>("MixtureRatio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly?>("Time")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("DeAntiIcingData");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FluidType = 1,
                            MixtureRatio = "50/50",
                            Time = new TimeOnly(8, 1, 11, 966).Add(TimeSpan.FromTicks(4543))
                        },
                        new
                        {
                            Id = 2,
                            FluidType = 2,
                            MixtureRatio = "50/50",
                            Time = new TimeOnly(3, 1, 11, 966).Add(TimeSpan.FromTicks(4560))
                        });
                });

            modelBuilder.Entity("PilotEntryService.Models.Entities.FuelData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("ActualUplift")
                        .HasColumnType("float");

                    b.Property<double>("FuelOnBoard")
                        .HasColumnType("float");

                    b.Property<double>("ParkingFuel")
                        .HasColumnType("float");

                    b.Property<double>("PlannedUplift")
                        .HasColumnType("float");

                    b.Property<double>("RevisedParkingFuel")
                        .HasColumnType("float");

                    b.Property<double>("UpliftInLiters")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("FuelData");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ActualUplift = 480.0,
                            FuelOnBoard = 1500.0,
                            ParkingFuel = 1000.0,
                            PlannedUplift = 500.0,
                            RevisedParkingFuel = 950.0,
                            UpliftInLiters = 600.0
                        },
                        new
                        {
                            Id = 2,
                            ActualUplift = 480.0,
                            FuelOnBoard = 1500.0,
                            ParkingFuel = 1000.0,
                            PlannedUplift = 500.0,
                            RevisedParkingFuel = 950.0,
                            UpliftInLiters = 600.0
                        });
                });

            modelBuilder.Entity("PilotEntryService.Models.Entities.Inspection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("PostFlightInspectionCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("PreFlightInspectionCompleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Inspections");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PostFlightInspectionCompleted = true,
                            PreFlightInspectionCompleted = true
                        },
                        new
                        {
                            Id = 2,
                            PostFlightInspectionCompleted = true,
                            PreFlightInspectionCompleted = true
                        });
                });

            modelBuilder.Entity("PilotEntryService.Models.Entities.TripLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AircraftRegistration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeAntiIcingDataId")
                        .HasColumnType("int");

                    b.Property<string>("DepartureAirport")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DestinationAirport")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("FlightNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("FuelDataId")
                        .HasColumnType("int");

                    b.Property<int>("InspectionId")
                        .HasColumnType("int");

                    b.Property<string>("PilotId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeAntiIcingDataId");

                    b.HasIndex("FuelDataId");

                    b.HasIndex("InspectionId");

                    b.ToTable("TripLogs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AircraftRegistration = "N12345",
                            ArrivalTime = new DateTime(2024, 10, 15, 12, 1, 11, 966, DateTimeKind.Utc).AddTicks(4739),
                            DeAntiIcingDataId = 1,
                            DepartureAirport = "JFK",
                            DepartureTime = new DateTime(2024, 10, 15, 7, 1, 11, 966, DateTimeKind.Utc).AddTicks(4738),
                            DestinationAirport = "LAX",
                            FlightNumber = "AB123",
                            FuelDataId = 1,
                            InspectionId = 1,
                            PilotId = "P001",
                            Remarks = "Smooth flight"
                        },
                        new
                        {
                            Id = 2,
                            AircraftRegistration = "N12345",
                            ArrivalTime = new DateTime(2024, 10, 15, 7, 1, 11, 966, DateTimeKind.Utc).AddTicks(4744),
                            DeAntiIcingDataId = 2,
                            DepartureAirport = "BLL",
                            DepartureTime = new DateTime(2024, 10, 15, 2, 1, 11, 966, DateTimeKind.Utc).AddTicks(4744),
                            DestinationAirport = "NVI",
                            FlightNumber = "AB124",
                            FuelDataId = 2,
                            InspectionId = 2,
                            PilotId = "P002",
                            Remarks = "kinda bumpy"
                        });
                });

            modelBuilder.Entity("PilotEntryService.Models.Entities.TripLog", b =>
                {
                    b.HasOne("PilotEntryService.Models.Entities.De_Anti_IcingData", "DeAntiIcingData")
                        .WithMany()
                        .HasForeignKey("DeAntiIcingDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PilotEntryService.Models.Entities.FuelData", "FuelData")
                        .WithMany()
                        .HasForeignKey("FuelDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PilotEntryService.Models.Entities.Inspection", "Inspection")
                        .WithMany()
                        .HasForeignKey("InspectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeAntiIcingData");

                    b.Navigation("FuelData");

                    b.Navigation("Inspection");
                });
#pragma warning restore 612, 618
        }
    }
}
