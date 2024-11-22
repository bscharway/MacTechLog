using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AircraftService.Migrations
{
    /// <inheritdoc />
    public partial class AddinglogID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaintenanceLogId",
                table: "FuelManagementData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TripLogId",
                table: "FuelManagementData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 20, 20, 47, 29, 327, DateTimeKind.Utc).AddTicks(5245));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 20, 20, 47, 29, 327, DateTimeKind.Utc).AddTicks(5247));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 20, 20, 47, 29, 327, DateTimeKind.Utc).AddTicks(5249));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 20, 20, 47, 29, 327, DateTimeKind.Utc).AddTicks(5250));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 20, 20, 47, 29, 327, DateTimeKind.Utc).AddTicks(5251));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 20, 20, 47, 29, 327, DateTimeKind.Utc).AddTicks(5253));

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MaintenanceLogId", "TripLogId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MaintenanceLogId", "TripLogId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MaintenanceLogId", "TripLogId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "MaintenanceLogId", "TripLogId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "MaintenanceLogId", "TripLogId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "MaintenanceLogId", "TripLogId" },
                values: new object[] { 0, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaintenanceLogId",
                table: "FuelManagementData");

            migrationBuilder.DropColumn(
                name: "TripLogId",
                table: "FuelManagementData");

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
        }
    }
}
