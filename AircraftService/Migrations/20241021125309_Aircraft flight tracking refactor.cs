using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AircraftService.Migrations
{
    /// <inheritdoc />
    public partial class Aircraftflighttrackingrefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuelCapacity",
                table: "Aircrafts");

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
                columns: new[] { "FuelCapacity", "LastRefueled" },
                values: new object[] { 26000, new DateTime(2024, 10, 20, 12, 53, 9, 142, DateTimeKind.Utc).AddTicks(4037) });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FuelCapacity", "LastRefueled" },
                values: new object[] { 24210, new DateTime(2024, 10, 19, 12, 53, 9, 142, DateTimeKind.Utc).AddTicks(4046) });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FuelCapacity", "LastRefueled" },
                values: new object[] { 183380, new DateTime(2024, 10, 18, 12, 53, 9, 142, DateTimeKind.Utc).AddTicks(4048) });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FuelCapacity", "LastRefueled" },
                values: new object[] { 320000, new DateTime(2024, 10, 17, 12, 53, 9, 142, DateTimeKind.Utc).AddTicks(4050) });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FuelCapacity", "LastRefueled" },
                values: new object[] { 13000, new DateTime(2024, 10, 16, 12, 53, 9, 142, DateTimeKind.Utc).AddTicks(4052) });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FuelCapacity", "LastRefueled" },
                values: new object[] { 210, new DateTime(2024, 10, 15, 12, 53, 9, 142, DateTimeKind.Utc).AddTicks(4053) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuelCapacity",
                table: "Aircrafts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FuelCapacity", "LastUpdated" },
                values: new object[] { 26000, new DateTime(2024, 10, 21, 12, 35, 3, 698, DateTimeKind.Utc).AddTicks(3441) });

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FuelCapacity", "LastUpdated" },
                values: new object[] { 24210, new DateTime(2024, 10, 21, 12, 35, 3, 698, DateTimeKind.Utc).AddTicks(3447) });

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FuelCapacity", "LastUpdated" },
                values: new object[] { 183380, new DateTime(2024, 10, 21, 12, 35, 3, 698, DateTimeKind.Utc).AddTicks(3449) });

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FuelCapacity", "LastUpdated" },
                values: new object[] { 320000, new DateTime(2024, 10, 21, 12, 35, 3, 698, DateTimeKind.Utc).AddTicks(3451) });

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FuelCapacity", "LastUpdated" },
                values: new object[] { 13000, new DateTime(2024, 10, 21, 12, 35, 3, 698, DateTimeKind.Utc).AddTicks(3453) });

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FuelCapacity", "LastUpdated" },
                values: new object[] { 210, new DateTime(2024, 10, 21, 12, 35, 3, 698, DateTimeKind.Utc).AddTicks(3455) });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FuelCapacity", "LastRefueled" },
                values: new object[] { 0, new DateTime(2024, 10, 20, 12, 35, 3, 698, DateTimeKind.Utc).AddTicks(3694) });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FuelCapacity", "LastRefueled" },
                values: new object[] { 0, new DateTime(2024, 10, 19, 12, 35, 3, 698, DateTimeKind.Utc).AddTicks(3705) });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FuelCapacity", "LastRefueled" },
                values: new object[] { 0, new DateTime(2024, 10, 18, 12, 35, 3, 698, DateTimeKind.Utc).AddTicks(3708) });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FuelCapacity", "LastRefueled" },
                values: new object[] { 0, new DateTime(2024, 10, 17, 12, 35, 3, 698, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FuelCapacity", "LastRefueled" },
                values: new object[] { 0, new DateTime(2024, 10, 16, 12, 35, 3, 698, DateTimeKind.Utc).AddTicks(3711) });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FuelCapacity", "LastRefueled" },
                values: new object[] { 0, new DateTime(2024, 10, 15, 12, 35, 3, 698, DateTimeKind.Utc).AddTicks(3713) });
        }
    }
}
