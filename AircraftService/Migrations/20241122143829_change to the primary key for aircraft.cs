using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AircraftService.Migrations
{
    /// <inheritdoc />
    public partial class changetotheprimarykeyforaircraft : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuelManagementData_Aircrafts_AircraftId",
                table: "FuelManagementData");

            migrationBuilder.DropIndex(
                name: "IX_FuelManagementData_AircraftId",
                table: "FuelManagementData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aircrafts",
                table: "Aircrafts");

            migrationBuilder.DeleteData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "AircraftId",
                table: "FuelManagementData");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Aircrafts");

            migrationBuilder.AddColumn<string>(
                name: "AircraftRegistration",
                table: "FuelManagementData",
                type: "nvarchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aircrafts",
                table: "Aircrafts",
                column: "Registration");

            migrationBuilder.InsertData(
                table: "Aircrafts",
                columns: new[] { "Registration", "CurrentStatus", "Cycles", "LastUpdated", "Model", "TotalFlightHours" },
                values: new object[,]
                {
                    { "D45678", "Airworthy", 3000, new DateTime(2024, 11, 22, 14, 38, 28, 832, DateTimeKind.Utc).AddTicks(5379), "Boeing 747", 10000 },
                    { "F12367", "Under Maintenance", 2000, new DateTime(2024, 11, 22, 14, 38, 28, 832, DateTimeKind.Utc).AddTicks(5380), "Airbus A380", 7000 },
                    { "G67890", "AOG", 1200, new DateTime(2024, 11, 22, 14, 38, 28, 832, DateTimeKind.Utc).AddTicks(5377), "Airbus A320", 4000 },
                    { "H89012", "Airworthy", 800, new DateTime(2024, 11, 22, 14, 38, 28, 832, DateTimeKind.Utc).AddTicks(5382), "Embraer E190", 2000 },
                    { "I34567", "Airworthy", 300, new DateTime(2024, 11, 22, 14, 38, 28, 832, DateTimeKind.Utc).AddTicks(5383), "Cessna 172", 500 },
                    { "N12345", "Airworthy", 1500, new DateTime(2024, 11, 22, 14, 38, 28, 832, DateTimeKind.Utc).AddTicks(5375), "Boeing 737", 5000 }
                });

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 1,
                column: "AircraftRegistration",
                value: "N12345");

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 2,
                column: "AircraftRegistration",
                value: "G67890");

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 3,
                column: "AircraftRegistration",
                value: "D45678");

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 4,
                column: "AircraftRegistration",
                value: "F12367");

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 5,
                column: "AircraftRegistration",
                value: "H89012");

            migrationBuilder.UpdateData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 6,
                column: "AircraftRegistration",
                value: "I34567");

            migrationBuilder.CreateIndex(
                name: "IX_FuelManagementData_AircraftRegistration",
                table: "FuelManagementData",
                column: "AircraftRegistration");

            migrationBuilder.AddForeignKey(
                name: "FK_FuelManagementData_Aircrafts_AircraftRegistration",
                table: "FuelManagementData",
                column: "AircraftRegistration",
                principalTable: "Aircrafts",
                principalColumn: "Registration",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuelManagementData_Aircrafts_AircraftRegistration",
                table: "FuelManagementData");

            migrationBuilder.DropIndex(
                name: "IX_FuelManagementData_AircraftRegistration",
                table: "FuelManagementData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aircrafts",
                table: "Aircrafts");

            migrationBuilder.DeleteData(
                table: "Aircrafts",
                keyColumn: "Registration",
                keyValue: "D45678");

            migrationBuilder.DeleteData(
                table: "Aircrafts",
                keyColumn: "Registration",
                keyValue: "F12367");

            migrationBuilder.DeleteData(
                table: "Aircrafts",
                keyColumn: "Registration",
                keyValue: "G67890");

            migrationBuilder.DeleteData(
                table: "Aircrafts",
                keyColumn: "Registration",
                keyValue: "H89012");

            migrationBuilder.DeleteData(
                table: "Aircrafts",
                keyColumn: "Registration",
                keyValue: "I34567");

            migrationBuilder.DeleteData(
                table: "Aircrafts",
                keyColumn: "Registration",
                keyValue: "N12345");

            migrationBuilder.DropColumn(
                name: "AircraftRegistration",
                table: "FuelManagementData");

            migrationBuilder.AddColumn<int>(
                name: "AircraftId",
                table: "FuelManagementData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Aircrafts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aircrafts",
                table: "Aircrafts",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Aircrafts",
                columns: new[] { "Id", "CurrentStatus", "Cycles", "LastUpdated", "Model", "Registration", "TotalFlightHours" },
                values: new object[,]
                {
                    { 1, "Airworthy", 1500, new DateTime(2024, 11, 22, 5, 48, 7, 434, DateTimeKind.Utc).AddTicks(9732), "Boeing 737", "N12345", 5000 },
                    { 2, "AOG", 1200, new DateTime(2024, 11, 22, 5, 48, 7, 434, DateTimeKind.Utc).AddTicks(9738), "Airbus A320", "G67890", 4000 },
                    { 3, "Airworthy", 3000, new DateTime(2024, 11, 22, 5, 48, 7, 434, DateTimeKind.Utc).AddTicks(9740), "Boeing 747", "D45678", 10000 },
                    { 4, "Under Maintenance", 2000, new DateTime(2024, 11, 22, 5, 48, 7, 434, DateTimeKind.Utc).AddTicks(9742), "Airbus A380", "F12367", 7000 },
                    { 5, "Airworthy", 800, new DateTime(2024, 11, 22, 5, 48, 7, 434, DateTimeKind.Utc).AddTicks(9744), "Embraer E190", "H89012", 2000 },
                    { 6, "Airworthy", 300, new DateTime(2024, 11, 22, 5, 48, 7, 434, DateTimeKind.Utc).AddTicks(9747), "Cessna 172", "I34567", 500 }
                });

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
    }
}
