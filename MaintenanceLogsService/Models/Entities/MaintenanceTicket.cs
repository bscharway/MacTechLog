namespace MaintenanceLogsService.Models.Entities
{
    // Maintenance Ticket Entity
    public class MaintenanceTicket
    {
        public int Id { get; set; }
        public string AircraftRegistration { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // e.g., "Open", "In Progress", "Resolved"
        public DateTime CreatedDate { get; set; }
        public DateTime? ResolvedDate { get; set; }
        public int? MaintenanceLogId { get; set; }
        public MaintenanceLog MaintenanceLog { get; set; }

        // Reference to TripLog ID
        public int? TripLogId { get; set; } // TripLog that triggered the ticket
    }

}
