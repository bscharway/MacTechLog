using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AircraftService.Migrations
{
    /// <inheritdoc />
    public partial class Aircraftflighttracking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cycles",
                table: "Aircrafts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalFlightHours",
                table: "Aircrafts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cycles", "LastUpdated", "TotalFlightHours" },
                values: new object[] { 1500, new DateTime(2024, 10, 21, 12, 35, 3, 698, DateTimeKind.Utc).AddTicks(3441), 5000 });

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cycles", "LastUpdated", "TotalFlightHours" },
                values: new object[] { 1200, new DateTime(2024, 10, 21, 12, 35, 3, 698, DateTimeKind.Utc).AddTicks(3447), 4000 });

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cycles", "LastUpdated", "TotalFlightHours" },
                values: new object[] { 3000, new DateTime(2024, 10, 21, 12, 35, 3, 698, DateTimeKind.Utc).AddTicks(3449), 10000 });

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Cycles", "LastUpdated", "TotalFlightHours" },
                values: new object[] { 2000, new DateTime(2024, 10, 21, 12, 35, 3, 698, DateTimeKind.Utc).AddTicks(3451), 7000 });

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Cycles", "LastUpdated", "TotalFlightHours" },
                values: new object[] { 800, new DateTime(2024, 10, 21, 12, 35, 3, 698, DateTimeKind.Utc).AddTicks(3453), 2000 });

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Cycles", "LastUpdated", "TotalFlightHours" },
                values: new object[] { 300, new DateTime(2024, 10, 21, 12, 35, 3, 698, DateTimeKind.Utc).AddTicks(3455), 500 });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastRefueled",
                value: new DateTime(2024, 10, 20, 12, 35, 3, 698, DateTimeKind.Utc).AddTicks(3694));

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastRefueled",
                value: new DateTime(2024, 10, 19, 12, 35, 3, 698, DateTimeKind.Utc).AddTicks(3705));

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastRefueled",
                value: new DateTime(2024, 10, 18, 12, 35, 3, 698, DateTimeKind.Utc).AddTicks(3708));

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastRefueled",
                value: new DateTime(2024, 10, 17, 12, 35, 3, 698, DateTimeKind.Utc).AddTicks(3710));

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastRefueled",
                value: new DateTime(2024, 10, 16, 12, 35, 3, 698, DateTimeKind.Utc).AddTicks(3711));

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastRefueled",
                value: new DateTime(2024, 10, 15, 12, 35, 3, 698, DateTimeKind.Utc).AddTicks(3713));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cycles",
                table: "Aircrafts");

            migrationBuilder.DropColumn(
                name: "TotalFlightHours",
                table: "Aircrafts");

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 18, 19, 17, 44, 825, DateTimeKind.Utc).AddTicks(3162));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 18, 19, 17, 44, 825, DateTimeKind.Utc).AddTicks(3165));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 18, 19, 17, 44, 825, DateTimeKind.Utc).AddTicks(3166));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 18, 19, 17, 44, 825, DateTimeKind.Utc).AddTicks(3167));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 18, 19, 17, 44, 825, DateTimeKind.Utc).AddTicks(3169));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2024, 10, 18, 19, 17, 44, 825, DateTimeKind.Utc).AddTicks(3170));

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastRefueled",
                value: new DateTime(2024, 10, 17, 19, 17, 44, 825, DateTimeKind.Utc).AddTicks(3315));

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastRefueled",
                value: new DateTime(2024, 10, 16, 19, 17, 44, 825, DateTimeKind.Utc).AddTicks(3321));

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastRefueled",
                value: new DateTime(2024, 10, 15, 19, 17, 44, 825, DateTimeKind.Utc).AddTicks(3323));

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastRefueled",
                value: new DateTime(2024, 10, 14, 19, 17, 44, 825, DateTimeKind.Utc).AddTicks(3364));

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastRefueled",
                value: new DateTime(2024, 10, 13, 19, 17, 44, 825, DateTimeKind.Utc).AddTicks(3365));

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastRefueled",
                value: new DateTime(2024, 10, 12, 19, 17, 44, 825, DateTimeKind.Utc).AddTicks(3366));
        }
    }
}
