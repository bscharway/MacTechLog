using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PilotEntryService.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DeAntiIcingData",
                columns: new[] { "Id", "FluidType", "MixtureRatio", "Time" },
                values: new object[,]
                {
                    { 1, 1, "50/50", new TimeOnly(8, 1, 11, 966).Add(TimeSpan.FromTicks(4543)) },
                    { 2, 2, "50/50", new TimeOnly(3, 1, 11, 966).Add(TimeSpan.FromTicks(4560)) }
                });

            migrationBuilder.InsertData(
                table: "FuelData",
                columns: new[] { "Id", "ActualUplift", "FuelOnBoard", "ParkingFuel", "PlannedUplift", "RevisedParkingFuel", "UpliftInLiters" },
                values: new object[,]
                {
                    { 1, 480.0, 1500.0, 1000.0, 500.0, 950.0, 600.0 },
                    { 2, 480.0, 1500.0, 1000.0, 500.0, 950.0, 600.0 }
                });

            migrationBuilder.InsertData(
                table: "Inspections",
                columns: new[] { "Id", "PostFlightInspectionCompleted", "PreFlightInspectionCompleted" },
                values: new object[,]
                {
                    { 1, true, true },
                    { 2, true, true }
                });

            migrationBuilder.InsertData(
                table: "TripLogs",
                columns: new[] { "Id", "AircraftRegistration", "ArrivalTime", "DeAntiIcingDataId", "DepartureAirport", "DepartureTime", "DestinationAirport", "FlightNumber", "FuelDataId", "InspectionId", "PilotId", "Remarks" },
                values: new object[,]
                {
                    { 1, "N12345", new DateTime(2024, 10, 15, 12, 1, 11, 966, DateTimeKind.Utc).AddTicks(4739), 1, "JFK", new DateTime(2024, 10, 15, 7, 1, 11, 966, DateTimeKind.Utc).AddTicks(4738), "LAX", "AB123", 1, 1, "P001", "Smooth flight" },
                    { 2, "N12345", new DateTime(2024, 10, 15, 7, 1, 11, 966, DateTimeKind.Utc).AddTicks(4744), 2, "BLL", new DateTime(2024, 10, 15, 2, 1, 11, 966, DateTimeKind.Utc).AddTicks(4744), "NVI", "AB124", 2, 2, "P002", "kinda bumpy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TripLogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TripLogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DeAntiIcingData",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DeAntiIcingData",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FuelData",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FuelData",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Inspections",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
