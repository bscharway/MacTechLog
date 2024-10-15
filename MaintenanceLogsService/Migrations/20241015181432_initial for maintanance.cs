using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceLogsService.Migrations
{
    /// <inheritdoc />
    public partial class initialformaintanance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OilHydraulicFluidData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    APUOilAdded = table.Column<double>(type: "float", nullable: true),
                    LeftHandEngineOilAdded = table.Column<double>(type: "float", nullable: true),
                    RightHandEngineOilAdded = table.Column<double>(type: "float", nullable: true),
                    LeftHandHydraulicSystemFluidAdded = table.Column<double>(type: "float", nullable: true),
                    RightHandHydraulicSystemFluidAdded = table.Column<double>(type: "float", nullable: true),
                    CenterHydraulicSystemFluidAdded = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OilHydraulicFluidData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AircraftRegistration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TechnicianId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MELReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOperationalProcedure = table.Column<bool>(type: "bit", nullable: false),
                    IsRepetitive = table.Column<bool>(type: "bit", nullable: false),
                    OilHydraulicFluidDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceLogs_OilHydraulicFluidData_OilHydraulicFluidDataId",
                        column: x => x.OilHydraulicFluidDataId,
                        principalTable: "OilHydraulicFluidData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DefectReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsResolved = table.Column<bool>(type: "bit", nullable: false),
                    MaintenanceLogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefectReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefectReports_MaintenanceLogs_MaintenanceLogId",
                        column: x => x.MaintenanceLogId,
                        principalTable: "MaintenanceLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartReplacements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenanceLogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartReplacements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartReplacements_MaintenanceLogs_MaintenanceLogId",
                        column: x => x.MaintenanceLogId,
                        principalTable: "MaintenanceLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DefectReports_MaintenanceLogId",
                table: "DefectReports",
                column: "MaintenanceLogId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceLogs_OilHydraulicFluidDataId",
                table: "MaintenanceLogs",
                column: "OilHydraulicFluidDataId");

            migrationBuilder.CreateIndex(
                name: "IX_PartReplacements_MaintenanceLogId",
                table: "PartReplacements",
                column: "MaintenanceLogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefectReports");

            migrationBuilder.DropTable(
                name: "PartReplacements");

            migrationBuilder.DropTable(
                name: "MaintenanceLogs");

            migrationBuilder.DropTable(
                name: "OilHydraulicFluidData");
        }
    }
}
