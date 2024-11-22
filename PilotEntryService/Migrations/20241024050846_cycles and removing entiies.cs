using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PilotEntryService.Migrations
{
    /// <inheritdoc />
    public partial class cyclesandremovingentiies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuelData");

            migrationBuilder.DropTable(
                name: "Inspections");

            migrationBuilder.UpdateData(
                table: "DeAntiIcingData",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new TimeOnly(1, 8, 45, 680).Add(TimeSpan.FromTicks(233)));

            migrationBuilder.UpdateData(
                table: "DeAntiIcingData",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new TimeOnly(20, 8, 45, 680).Add(TimeSpan.FromTicks(250)));

            migrationBuilder.UpdateData(
                table: "TripLogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActualTimeOfDeparture", "ActualTimeOfLanding", "Cycles", "OffBlockTime", "OnBlockTime" },
                values: new object[] { new DateTime(2024, 10, 24, 0, 13, 45, 680, DateTimeKind.Utc).AddTicks(420), new DateTime(2024, 10, 24, 5, 3, 45, 680, DateTimeKind.Utc).AddTicks(421), 1, new DateTime(2024, 10, 24, 0, 8, 45, 680, DateTimeKind.Utc).AddTicks(419), new DateTime(2024, 10, 24, 5, 8, 45, 680, DateTimeKind.Utc).AddTicks(423) });

            migrationBuilder.UpdateData(
                table: "TripLogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ActualTimeOfDeparture", "ActualTimeOfLanding", "Cycles", "OffBlockTime", "OnBlockTime" },
                values: new object[] { new DateTime(2024, 10, 23, 19, 13, 45, 680, DateTimeKind.Utc).AddTicks(436), new DateTime(2024, 10, 24, 0, 3, 45, 680, DateTimeKind.Utc).AddTicks(437), 1, new DateTime(2024, 10, 23, 19, 8, 45, 680, DateTimeKind.Utc).AddTicks(436), new DateTime(2024, 10, 24, 0, 8, 45, 680, DateTimeKind.Utc).AddTicks(438) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuelData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActualUplift = table.Column<double>(type: "float", nullable: true),
                    FuelOnBoard = table.Column<double>(type: "float", nullable: true),
                    ParkingFuel = table.Column<double>(type: "float", nullable: false),
                    PlannedUplift = table.Column<double>(type: "float", nullable: true),
                    RevisedParkingFuel = table.Column<double>(type: "float", nullable: true),
                    UpliftInLiters = table.Column<double>(type: "float", nullable: true),
                    landingfuel = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostFlightInspectionCompleted = table.Column<bool>(type: "bit", nullable: false),
                    PreFlightInspectionCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.Id);
                });

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
                columns: new[] { "ActualTimeOfDeparture", "ActualTimeOfLanding", "Cycles", "OffBlockTime", "OnBlockTime" },
                values: new object[] { new DateTime(2024, 10, 23, 23, 56, 55, 968, DateTimeKind.Utc).AddTicks(9691), new DateTime(2024, 10, 24, 4, 46, 55, 968, DateTimeKind.Utc).AddTicks(9696), 0, new DateTime(2024, 10, 23, 23, 51, 55, 968, DateTimeKind.Utc).AddTicks(9689), new DateTime(2024, 10, 24, 4, 51, 55, 968, DateTimeKind.Utc).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "TripLogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ActualTimeOfDeparture", "ActualTimeOfLanding", "Cycles", "OffBlockTime", "OnBlockTime" },
                values: new object[] { new DateTime(2024, 10, 23, 18, 56, 55, 968, DateTimeKind.Utc).AddTicks(9707), new DateTime(2024, 10, 23, 23, 46, 55, 968, DateTimeKind.Utc).AddTicks(9708), 0, new DateTime(2024, 10, 23, 18, 51, 55, 968, DateTimeKind.Utc).AddTicks(9706), new DateTime(2024, 10, 23, 23, 51, 55, 968, DateTimeKind.Utc).AddTicks(9708) });
        }
    }
}
