using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AircraftService.Migrations
{
    /// <inheritdoc />
    public partial class derivingfuelcomsumptionfrom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuelCapacity",
                table: "FuelManagementData");

            migrationBuilder.DropColumn(
                name: "FuelOnBoard",
                table: "FuelManagementData");

            migrationBuilder.DropColumn(
                name: "LastRefueled",
                table: "FuelManagementData");

            migrationBuilder.RenameColumn(
                name: "RecentUplift",
                table: "FuelManagementData",
                newName: "LatestRecordedFuelOnBoard");

            migrationBuilder.AddColumn<double>(
                name: "ActualUplift",
                table: "FuelManagementData",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LandingFuel",
                table: "FuelManagementData",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "RevisedParkingFuel",
                table: "FuelManagementData",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "UpliftInLiters",
                table: "FuelManagementData",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 17, 15, 6, 15, 889, DateTimeKind.Utc).AddTicks(4978));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 17, 15, 6, 15, 889, DateTimeKind.Utc).AddTicks(4981));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 17, 15, 6, 15, 889, DateTimeKind.Utc).AddTicks(4982));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 17, 15, 6, 15, 889, DateTimeKind.Utc).AddTicks(4984));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 17, 15, 6, 15, 889, DateTimeKind.Utc).AddTicks(4986));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 17, 15, 6, 15, 889, DateTimeKind.Utc).AddTicks(4987));

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActualUplift", "LandingFuel", "LatestRecordedFuelOnBoard", "PlannedUplift", "RevisedParkingFuel", "UpliftInLiters" },
                values: new object[] { 5000.0, 10000.0, 15000.0, 5000.0, 15000.0, 2700.0 });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ActualUplift", "LandingFuel", "LatestRecordedFuelOnBoard", "PlannedUplift", "RevisedParkingFuel", "UpliftInLiters" },
                values: new object[] { 3100.0, 6000.0, 12000.0, 3000.0, 12000.0, 1500.0 });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ActualUplift", "LandingFuel", "LatestRecordedFuelOnBoard", "PlannedUplift", "RevisedParkingFuel", "UpliftInLiters" },
                values: new object[] { 30100.0, 30000.0, 20000.0, 30000.0, 19500.0, 15000.0 });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ActualUplift", "LandingFuel", "LatestRecordedFuelOnBoard", "PlannedUplift", "RevisedParkingFuel", "UpliftInLiters" },
                values: new object[] { 21000.0, 30000.0, 25000.0, 20000.0, 24500.0, 22000.0 });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ActualUplift", "LandingFuel", "LatestRecordedFuelOnBoard", "PlannedUplift", "RevisedParkingFuel", "UpliftInLiters" },
                values: new object[] { 2100.0, 3400.0, 5000.0, 2000.0, 5000.0, 3200.0 });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ActualUplift", "LandingFuel", "LatestRecordedFuelOnBoard", "PlannedUplift", "RevisedParkingFuel", "UpliftInLiters" },
                values: new object[] { 22100.0, 32400.0, 52000.0, 22000.0, 52000.0, 32200.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualUplift",
                table: "FuelManagementData");

            migrationBuilder.DropColumn(
                name: "LandingFuel",
                table: "FuelManagementData");

            migrationBuilder.DropColumn(
                name: "RevisedParkingFuel",
                table: "FuelManagementData");

            migrationBuilder.DropColumn(
                name: "UpliftInLiters",
                table: "FuelManagementData");

            migrationBuilder.RenameColumn(
                name: "LatestRecordedFuelOnBoard",
                table: "FuelManagementData",
                newName: "RecentUplift");

            migrationBuilder.AddColumn<int>(
                name: "FuelCapacity",
                table: "FuelManagementData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "FuelOnBoard",
                table: "FuelManagementData",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastRefueled",
                table: "FuelManagementData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 21, 12, 53, 9, 142, DateTimeKind.Utc).AddTicks(3799));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 21, 12, 53, 9, 142, DateTimeKind.Utc).AddTicks(3804));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 21, 12, 53, 9, 142, DateTimeKind.Utc).AddTicks(3806));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 21, 12, 53, 9, 142, DateTimeKind.Utc).AddTicks(3808));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 21, 12, 53, 9, 142, DateTimeKind.Utc).AddTicks(3811));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 21, 12, 53, 9, 142, DateTimeKind.Utc).AddTicks(3813));

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FuelCapacity", "FuelOnBoard", "LastRefueled", "PlannedUplift", "RecentUplift" },
                values: new object[] { 26000, 15000.0, new DateTime(2024, 10, 20, 12, 53, 9, 142, DateTimeKind.Utc).AddTicks(4037), 6000.0, 5000.0 });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FuelCapacity", "FuelOnBoard", "LastRefueled", "PlannedUplift", "RecentUplift" },
                values: new object[] { 24210, 12000.0, new DateTime(2024, 10, 19, 12, 53, 9, 142, DateTimeKind.Utc).AddTicks(4046), 5000.0, 3000.0 });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FuelCapacity", "FuelOnBoard", "LastRefueled", "PlannedUplift", "RecentUplift" },
                values: new object[] { 183380, 80000.0, new DateTime(2024, 10, 18, 12, 53, 9, 142, DateTimeKind.Utc).AddTicks(4048), 60000.0, 50000.0 });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FuelCapacity", "FuelOnBoard", "LastRefueled", "PlannedUplift", "RecentUplift" },
                values: new object[] { 320000, 250000.0, new DateTime(2024, 10, 17, 12, 53, 9, 142, DateTimeKind.Utc).AddTicks(4050), 80000.0, 70000.0 });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FuelCapacity", "FuelOnBoard", "LastRefueled", "PlannedUplift", "RecentUplift" },
                values: new object[] { 13000, 8000.0, new DateTime(2024, 10, 16, 12, 53, 9, 142, DateTimeKind.Utc).AddTicks(4052), 4000.0, 3000.0 });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FuelCapacity", "FuelOnBoard", "LastRefueled", "PlannedUplift", "RecentUplift" },
                values: new object[] { 210, 100.0, new DateTime(2024, 10, 15, 12, 53, 9, 142, DateTimeKind.Utc).AddTicks(4053), 70.0, 50.0 });
        }
    }
}
