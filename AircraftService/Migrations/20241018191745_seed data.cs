using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AircraftService.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aircrafts_FuelManagementData_FuelManagementId",
                table: "Aircrafts");

            migrationBuilder.RenameColumn(
                name: "FuelManagementId",
                table: "Aircrafts",
                newName: "FuelManagementDataId");

            migrationBuilder.RenameIndex(
                name: "IX_Aircrafts_FuelManagementId",
                table: "Aircrafts",
                newName: "IX_Aircrafts_FuelManagementDataId");

            migrationBuilder.AddColumn<int>(
                name: "FuelCapacity",
                table: "FuelManagementData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Registration",
                table: "Aircrafts",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Aircrafts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "FuelCapacity",
                table: "Aircrafts",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentStatus",
                table: "Aircrafts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "FuelManagementData",
                columns: new[] { "Id", "FuelCapacity", "FuelOnBoard", "LastRefueled", "PlannedUplift", "RecentUplift" },
                values: new object[,]
                {
                    { 1, 0, 15000.0, new DateTime(2024, 10, 17, 19, 17, 44, 825, DateTimeKind.Utc).AddTicks(3315), 6000.0, 5000.0 },
                    { 2, 0, 12000.0, new DateTime(2024, 10, 16, 19, 17, 44, 825, DateTimeKind.Utc).AddTicks(3321), 5000.0, 3000.0 },
                    { 3, 0, 80000.0, new DateTime(2024, 10, 15, 19, 17, 44, 825, DateTimeKind.Utc).AddTicks(3323), 60000.0, 50000.0 },
                    { 4, 0, 250000.0, new DateTime(2024, 10, 14, 19, 17, 44, 825, DateTimeKind.Utc).AddTicks(3364), 80000.0, 70000.0 },
                    { 5, 0, 8000.0, new DateTime(2024, 10, 13, 19, 17, 44, 825, DateTimeKind.Utc).AddTicks(3365), 4000.0, 3000.0 },
                    { 6, 0, 100.0, new DateTime(2024, 10, 12, 19, 17, 44, 825, DateTimeKind.Utc).AddTicks(3366), 70.0, 50.0 }
                });

            migrationBuilder.InsertData(
                table: "Aircrafts",
                columns: new[] { "Id", "CurrentStatus", "FuelCapacity", "FuelManagementDataId", "LastUpdated", "Model", "Registration" },
                values: new object[,]
                {
                    { 1, "Airworthy", 26000, 1, new DateTime(2024, 10, 18, 19, 17, 44, 825, DateTimeKind.Utc).AddTicks(3162), "Boeing 737", "N12345" },
                    { 2, "AOG", 24210, 2, new DateTime(2024, 10, 18, 19, 17, 44, 825, DateTimeKind.Utc).AddTicks(3165), "Airbus A320", "G67890" },
                    { 3, "Airworthy", 183380, 3, new DateTime(2024, 10, 18, 19, 17, 44, 825, DateTimeKind.Utc).AddTicks(3166), "Boeing 747", "D45678" },
                    { 4, "Under Maintenance", 320000, 4, new DateTime(2024, 10, 18, 19, 17, 44, 825, DateTimeKind.Utc).AddTicks(3167), "Airbus A380", "F12367" },
                    { 5, "Airworthy", 13000, 5, new DateTime(2024, 10, 18, 19, 17, 44, 825, DateTimeKind.Utc).AddTicks(3169), "Embraer E190", "H89012" },
                    { 6, "Airworthy", 210, 6, new DateTime(2024, 10, 18, 19, 17, 44, 825, DateTimeKind.Utc).AddTicks(3170), "Cessna 172", "I34567" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Aircrafts_FuelManagementData_FuelManagementDataId",
                table: "Aircrafts",
                column: "FuelManagementDataId",
                principalTable: "FuelManagementData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aircrafts_FuelManagementData_FuelManagementDataId",
                table: "Aircrafts");

            migrationBuilder.DeleteData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FuelManagementData",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "FuelCapacity",
                table: "FuelManagementData");

            migrationBuilder.RenameColumn(
                name: "FuelManagementDataId",
                table: "Aircrafts",
                newName: "FuelManagementId");

            migrationBuilder.RenameIndex(
                name: "IX_Aircrafts_FuelManagementDataId",
                table: "Aircrafts",
                newName: "IX_Aircrafts_FuelManagementId");

            migrationBuilder.AlterColumn<string>(
                name: "Registration",
                table: "Aircrafts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Aircrafts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<double>(
                name: "FuelCapacity",
                table: "Aircrafts",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentStatus",
                table: "Aircrafts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_Aircrafts_FuelManagementData_FuelManagementId",
                table: "Aircrafts",
                column: "FuelManagementId",
                principalTable: "FuelManagementData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
