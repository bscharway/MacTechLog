using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PilotEntryService.Migrations
{
    /// <inheritdoc />
    public partial class blockTimesandputtingtablestogether : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripLogs_FuelData_FuelDataId",
                table: "TripLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_TripLogs_Inspections_InspectionId",
                table: "TripLogs");

            migrationBuilder.DropIndex(
                name: "IX_TripLogs_FuelDataId",
                table: "TripLogs");

            migrationBuilder.DropIndex(
                name: "IX_TripLogs_InspectionId",
                table: "TripLogs");

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

            migrationBuilder.DropColumn(
                name: "FuelDataId",
                table: "TripLogs");

            migrationBuilder.RenameColumn(
                name: "InspectionId",
                table: "TripLogs",
                newName: "Cycles");

            migrationBuilder.RenameColumn(
                name: "DepartureTime",
                table: "TripLogs",
                newName: "OnBlockTime");

            migrationBuilder.RenameColumn(
                name: "ArrivalTime",
                table: "TripLogs",
                newName: "OffBlockTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualTimeOfDeparture",
                table: "TripLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualTimeOfLanding",
                table: "TripLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "ActualUplift",
                table: "TripLogs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FuelOnBoard",
                table: "TripLogs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ParkingFuel",
                table: "TripLogs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PlannedUplift",
                table: "TripLogs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PostFlightInspectionCompleted",
                table: "TripLogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PreFlightInspectionCompleted",
                table: "TripLogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "RevisedParkingFuel",
                table: "TripLogs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "UpliftInLiters",
                table: "TripLogs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "landingfuel",
                table: "TripLogs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "landingfuel",
                table: "FuelData",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "DeAntiIcingData",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new TimeOnly(0, 51, 55, 968).Add(TimeSpan.FromTicks(9549)));

            migrationBuilder.UpdateData(
                table: "DeAntiIcingData",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new TimeOnly(19, 51, 55, 968).Add(TimeSpan.FromTicks(9563)));

            migrationBuilder.UpdateData(
                table: "TripLogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActualTimeOfDeparture", "ActualTimeOfLanding", "ActualUplift", "Cycles", "FuelOnBoard", "OffBlockTime", "OnBlockTime", "ParkingFuel", "PlannedUplift", "PostFlightInspectionCompleted", "PreFlightInspectionCompleted", "RevisedParkingFuel", "UpliftInLiters", "landingfuel" },
                values: new object[] { new DateTime(2024, 10, 23, 23, 56, 55, 968, DateTimeKind.Utc).AddTicks(9691), new DateTime(2024, 10, 24, 4, 46, 55, 968, DateTimeKind.Utc).AddTicks(9696), 480.0, 0, 1500.0, new DateTime(2024, 10, 23, 23, 51, 55, 968, DateTimeKind.Utc).AddTicks(9689), new DateTime(2024, 10, 24, 4, 51, 55, 968, DateTimeKind.Utc).AddTicks(9697), 1000.0, 500.0, true, true, 950.0, 600.0, 800.0 });

            migrationBuilder.UpdateData(
                table: "TripLogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ActualTimeOfDeparture", "ActualTimeOfLanding", "ActualUplift", "Cycles", "FuelOnBoard", "OffBlockTime", "OnBlockTime", "ParkingFuel", "PlannedUplift", "PostFlightInspectionCompleted", "PreFlightInspectionCompleted", "Remarks", "RevisedParkingFuel", "UpliftInLiters", "landingfuel" },
                values: new object[] { new DateTime(2024, 10, 23, 18, 56, 55, 968, DateTimeKind.Utc).AddTicks(9707), new DateTime(2024, 10, 23, 23, 46, 55, 968, DateTimeKind.Utc).AddTicks(9708), 480.0, 0, 1500.0, new DateTime(2024, 10, 23, 18, 51, 55, 968, DateTimeKind.Utc).AddTicks(9706), new DateTime(2024, 10, 23, 23, 51, 55, 968, DateTimeKind.Utc).AddTicks(9708), 1000.0, 500.0, true, true, "Kinda bumpy", 950.0, 600.0, 700.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualTimeOfDeparture",
                table: "TripLogs");

            migrationBuilder.DropColumn(
                name: "ActualTimeOfLanding",
                table: "TripLogs");

            migrationBuilder.DropColumn(
                name: "ActualUplift",
                table: "TripLogs");

            migrationBuilder.DropColumn(
                name: "FuelOnBoard",
                table: "TripLogs");

            migrationBuilder.DropColumn(
                name: "ParkingFuel",
                table: "TripLogs");

            migrationBuilder.DropColumn(
                name: "PlannedUplift",
                table: "TripLogs");

            migrationBuilder.DropColumn(
                name: "PostFlightInspectionCompleted",
                table: "TripLogs");

            migrationBuilder.DropColumn(
                name: "PreFlightInspectionCompleted",
                table: "TripLogs");

            migrationBuilder.DropColumn(
                name: "RevisedParkingFuel",
                table: "TripLogs");

            migrationBuilder.DropColumn(
                name: "UpliftInLiters",
                table: "TripLogs");

            migrationBuilder.DropColumn(
                name: "landingfuel",
                table: "TripLogs");

            migrationBuilder.DropColumn(
                name: "landingfuel",
                table: "FuelData");

            migrationBuilder.RenameColumn(
                name: "OnBlockTime",
                table: "TripLogs",
                newName: "DepartureTime");

            migrationBuilder.RenameColumn(
                name: "OffBlockTime",
                table: "TripLogs",
                newName: "ArrivalTime");

            migrationBuilder.RenameColumn(
                name: "Cycles",
                table: "TripLogs",
                newName: "InspectionId");

            migrationBuilder.AddColumn<int>(
                name: "FuelDataId",
                table: "TripLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DeAntiIcingData",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new TimeOnly(10, 31, 40, 871).Add(TimeSpan.FromTicks(6994)));

            migrationBuilder.UpdateData(
                table: "DeAntiIcingData",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new TimeOnly(5, 31, 40, 871).Add(TimeSpan.FromTicks(7008)));

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

            migrationBuilder.UpdateData(
                table: "TripLogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalTime", "DepartureTime", "FuelDataId", "InspectionId" },
                values: new object[] { new DateTime(2024, 10, 15, 14, 31, 40, 871, DateTimeKind.Utc).AddTicks(7198), new DateTime(2024, 10, 15, 9, 31, 40, 871, DateTimeKind.Utc).AddTicks(7197), 1, 1 });

            migrationBuilder.UpdateData(
                table: "TripLogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "DepartureTime", "FuelDataId", "InspectionId", "Remarks" },
                values: new object[] { new DateTime(2024, 10, 15, 9, 31, 40, 871, DateTimeKind.Utc).AddTicks(7204), new DateTime(2024, 10, 15, 4, 31, 40, 871, DateTimeKind.Utc).AddTicks(7203), 2, 2, "kinda bumpy" });

            migrationBuilder.CreateIndex(
                name: "IX_TripLogs_FuelDataId",
                table: "TripLogs",
                column: "FuelDataId");

            migrationBuilder.CreateIndex(
                name: "IX_TripLogs_InspectionId",
                table: "TripLogs",
                column: "InspectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TripLogs_FuelData_FuelDataId",
                table: "TripLogs",
                column: "FuelDataId",
                principalTable: "FuelData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripLogs_Inspections_InspectionId",
                table: "TripLogs",
                column: "InspectionId",
                principalTable: "Inspections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
