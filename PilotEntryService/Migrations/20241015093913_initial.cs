using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PilotEntryService.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeAntiIcingData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FluidType = table.Column<int>(type: "int", nullable: false),
                    MixtureRatio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeAntiIcingData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingFuel = table.Column<double>(type: "float", nullable: false),
                    RevisedParkingFuel = table.Column<double>(type: "float", nullable: false),
                    PlannedUplift = table.Column<double>(type: "float", nullable: false),
                    ActualUplift = table.Column<double>(type: "float", nullable: false),
                    FuelOnBoard = table.Column<double>(type: "float", nullable: false),
                    UpliftInLiters = table.Column<double>(type: "float", nullable: false)
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
                    PreFlightInspectionCompleted = table.Column<bool>(type: "bit", nullable: false),
                    PostFlightInspectionCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TripLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AircraftRegistration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PilotId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureAirport = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    DestinationAirport = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeAntiIcingDataId = table.Column<int>(type: "int", nullable: false),
                    FuelDataId = table.Column<int>(type: "int", nullable: false),
                    InspectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripLogs_DeAntiIcingData_DeAntiIcingDataId",
                        column: x => x.DeAntiIcingDataId,
                        principalTable: "DeAntiIcingData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripLogs_FuelData_FuelDataId",
                        column: x => x.FuelDataId,
                        principalTable: "FuelData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripLogs_Inspections_InspectionId",
                        column: x => x.InspectionId,
                        principalTable: "Inspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TripLogs_DeAntiIcingDataId",
                table: "TripLogs",
                column: "DeAntiIcingDataId");

            migrationBuilder.CreateIndex(
                name: "IX_TripLogs_FuelDataId",
                table: "TripLogs",
                column: "FuelDataId");

            migrationBuilder.CreateIndex(
                name: "IX_TripLogs_InspectionId",
                table: "TripLogs",
                column: "InspectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripLogs");

            migrationBuilder.DropTable(
                name: "DeAntiIcingData");

            migrationBuilder.DropTable(
                name: "FuelData");

            migrationBuilder.DropTable(
                name: "Inspections");
        }
    }
}
