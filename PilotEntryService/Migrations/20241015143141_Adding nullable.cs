using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PilotEntryService.Migrations
{
    /// <inheritdoc />
    public partial class Addingnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripLogs_DeAntiIcingData_DeAntiIcingDataId",
                table: "TripLogs");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "TripLogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DepartureAirport",
                table: "TripLogs",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<int>(
                name: "DeAntiIcingDataId",
                table: "TripLogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "UpliftInLiters",
                table: "FuelData",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "RevisedParkingFuel",
                table: "FuelData",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "PlannedUplift",
                table: "FuelData",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "FuelOnBoard",
                table: "FuelData",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "ActualUplift",
                table: "FuelData",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

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

            migrationBuilder.UpdateData(
                table: "TripLogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 10, 15, 14, 31, 40, 871, DateTimeKind.Utc).AddTicks(7198), new DateTime(2024, 10, 15, 9, 31, 40, 871, DateTimeKind.Utc).AddTicks(7197) });

            migrationBuilder.UpdateData(
                table: "TripLogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 10, 15, 9, 31, 40, 871, DateTimeKind.Utc).AddTicks(7204), new DateTime(2024, 10, 15, 4, 31, 40, 871, DateTimeKind.Utc).AddTicks(7203) });

            migrationBuilder.AddForeignKey(
                name: "FK_TripLogs_DeAntiIcingData_DeAntiIcingDataId",
                table: "TripLogs",
                column: "DeAntiIcingDataId",
                principalTable: "DeAntiIcingData",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripLogs_DeAntiIcingData_DeAntiIcingDataId",
                table: "TripLogs");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "TripLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DepartureAirport",
                table: "TripLogs",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeAntiIcingDataId",
                table: "TripLogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "UpliftInLiters",
                table: "FuelData",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "RevisedParkingFuel",
                table: "FuelData",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PlannedUplift",
                table: "FuelData",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "FuelOnBoard",
                table: "FuelData",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ActualUplift",
                table: "FuelData",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "DeAntiIcingData",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new TimeOnly(8, 1, 11, 966).Add(TimeSpan.FromTicks(4543)));

            migrationBuilder.UpdateData(
                table: "DeAntiIcingData",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new TimeOnly(3, 1, 11, 966).Add(TimeSpan.FromTicks(4560)));

            migrationBuilder.UpdateData(
                table: "TripLogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 10, 15, 12, 1, 11, 966, DateTimeKind.Utc).AddTicks(4739), new DateTime(2024, 10, 15, 7, 1, 11, 966, DateTimeKind.Utc).AddTicks(4738) });

            migrationBuilder.UpdateData(
                table: "TripLogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 10, 15, 7, 1, 11, 966, DateTimeKind.Utc).AddTicks(4744), new DateTime(2024, 10, 15, 2, 1, 11, 966, DateTimeKind.Utc).AddTicks(4744) });

            migrationBuilder.AddForeignKey(
                name: "FK_TripLogs_DeAntiIcingData_DeAntiIcingDataId",
                table: "TripLogs",
                column: "DeAntiIcingDataId",
                principalTable: "DeAntiIcingData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
