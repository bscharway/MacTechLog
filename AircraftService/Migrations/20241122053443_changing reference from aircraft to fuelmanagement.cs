using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AircraftService.Migrations
{
    /// <inheritdoc />
    public partial class changingreferencefromaircrafttofuelmanagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aircrafts_FuelManagementData_FuelManagementDataId",
                table: "Aircrafts");

            migrationBuilder.DropIndex(
                name: "IX_Aircrafts_FuelManagementDataId",
                table: "Aircrafts");

            migrationBuilder.DropColumn(
                name: "FuelManagementDataId",
                table: "Aircrafts");

            migrationBuilder.AddColumn<int>(
                name: "AircraftId",
                table: "FuelManagementData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 22, 5, 34, 43, 37, DateTimeKind.Utc).AddTicks(7723));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 22, 5, 34, 43, 37, DateTimeKind.Utc).AddTicks(7727));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 22, 5, 34, 43, 37, DateTimeKind.Utc).AddTicks(7729));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 22, 5, 34, 43, 37, DateTimeKind.Utc).AddTicks(7731));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 22, 5, 34, 43, 37, DateTimeKind.Utc).AddTicks(7733));

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2024, 11, 22, 5, 34, 43, 37, DateTimeKind.Utc).AddTicks(7735));

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 1,
                column: "AircraftId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 2,
                column: "AircraftId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 3,
                column: "AircraftId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 4,
                column: "AircraftId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 5,
                column: "AircraftId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 6,
                column: "AircraftId",
                value: 6);

            migrationBuilder.CreateIndex(
                name: "IX_FuelManagementData_AircraftId",
                table: "FuelManagementData",
                column: "AircraftId");

            migrationBuilder.AddForeignKey(
                name: "FK_FuelManagementData_Aircrafts_AircraftId",
                table: "FuelManagementData",
                column: "AircraftId",
                principalTable: "Aircrafts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuelManagementData_Aircrafts_AircraftId",
                table: "FuelManagementData");

            migrationBuilder.DropIndex(
                name: "IX_FuelManagementData_AircraftId",
                table: "FuelManagementData");

            migrationBuilder.DropColumn(
                name: "AircraftId",
                table: "FuelManagementData");

            migrationBuilder.AddColumn<int>(
                name: "FuelManagementDataId",
                table: "Aircrafts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FuelManagementDataId", "LastUpdated" },
                values: new object[] { 1, new DateTime(2024, 11, 20, 20, 48, 39, 596, DateTimeKind.Utc).AddTicks(9207) });

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FuelManagementDataId", "LastUpdated" },
                values: new object[] { 2, new DateTime(2024, 11, 20, 20, 48, 39, 596, DateTimeKind.Utc).AddTicks(9210) });

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FuelManagementDataId", "LastUpdated" },
                values: new object[] { 3, new DateTime(2024, 11, 20, 20, 48, 39, 596, DateTimeKind.Utc).AddTicks(9211) });

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FuelManagementDataId", "LastUpdated" },
                values: new object[] { 4, new DateTime(2024, 11, 20, 20, 48, 39, 596, DateTimeKind.Utc).AddTicks(9213) });

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FuelManagementDataId", "LastUpdated" },
                values: new object[] { 5, new DateTime(2024, 11, 20, 20, 48, 39, 596, DateTimeKind.Utc).AddTicks(9214) });

            migrationBuilder.UpdateData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FuelManagementDataId", "LastUpdated" },
                values: new object[] { 6, new DateTime(2024, 11, 20, 20, 48, 39, 596, DateTimeKind.Utc).AddTicks(9215) });

            migrationBuilder.CreateIndex(
                name: "IX_Aircrafts_FuelManagementDataId",
                table: "Aircrafts",
                column: "FuelManagementDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aircrafts_FuelManagementData_FuelManagementDataId",
                table: "Aircrafts",
                column: "FuelManagementDataId",
                principalTable: "FuelManagementData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
