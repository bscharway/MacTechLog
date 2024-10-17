using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintenanceLogsService.Migrations
{
    /// <inheritdoc />
    public partial class Tracingtickettopilotentry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TripLogId",
                table: "MaintenanceTickets",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TripLogId",
                table: "MaintenanceTickets");
        }
    }
}
