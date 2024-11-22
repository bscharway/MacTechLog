using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AircraftService.Migrations
{
    /// <inheritdoc />
    public partial class logIDnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TripLogId",
                table: "FuelManagementData",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaintenanceLogId",
                table: "FuelManagementData",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 20, 20, 48, 39, 596, DateTimeKind.Utc).AddTicks(9207));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 20, 20, 48, 39, 596, DateTimeKind.Utc).AddTicks(9210));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 20, 20, 48, 39, 596, DateTimeKind.Utc).AddTicks(9211));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 20, 20, 48, 39, 596, DateTimeKind.Utc).AddTicks(9213));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 20, 20, 48, 39, 596, DateTimeKind.Utc).AddTicks(9214));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 20, 20, 48, 39, 596, DateTimeKind.Utc).AddTicks(9215));

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MaintenanceLogId", "TripLogId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MaintenanceLogId", "TripLogId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MaintenanceLogId", "TripLogId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "MaintenanceLogId", "TripLogId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "MaintenanceLogId", "TripLogId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "MaintenanceLogId", "TripLogId" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TripLogId",
                table: "FuelManagementData",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaintenanceLogId",
                table: "FuelManagementData",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
