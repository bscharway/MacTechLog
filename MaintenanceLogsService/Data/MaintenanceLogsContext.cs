using MaintenanceLogsService.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MaintenanceLogsService.Data
{
    // Entity Framework Context
    public class MaintenanceLogsContext : DbContext
    {
        public MaintenanceLogsContext(DbContextOptions<MaintenanceLogsContext> options) : base(options)
        {
        }

        public DbSet<MaintenanceLog> MaintenanceLogs { get; set; }
        public DbSet<DefectReport> DefectReports { get; set; }
        public DbSet<PartReplacement> PartReplacements { get; set; }
        public DbSet<MaintenanceTicket> MaintenanceTickets { get; set; }
    }
}
