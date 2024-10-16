using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceLogsService.Migrations
{
    /// <inheritdoc />
    public partial class addingnullables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceLogs_OilHydraulicFluidData_OilHydraulicFluidDataId",
                table: "MaintenanceLogs");

            migrationBuilder.AlterColumn<int>(
                name: "OilHydraulicFluidDataId",
                table: "MaintenanceLogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceLogs_OilHydraulicFluidData_OilHydraulicFluidDataId",
                table: "MaintenanceLogs",
                column: "OilHydraulicFluidDataId",
                principalTable: "OilHydraulicFluidData",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceLogs_OilHydraulicFluidData_OilHydraulicFluidDataId",
                table: "MaintenanceLogs");

            migrationBuilder.AlterColumn<int>(
                name: "OilHydraulicFluidDataId",
                table: "MaintenanceLogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceLogs_OilHydraulicFluidData_OilHydraulicFluidDataId",
                table: "MaintenanceLogs",
                column: "OilHydraulicFluidDataId",
                principalTable: "OilHydraulicFluidData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
