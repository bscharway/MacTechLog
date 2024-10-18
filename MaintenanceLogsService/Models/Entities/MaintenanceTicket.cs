using System.ComponentModel.DataAnnotations;

namespace MaintenanceLogsService.Models.Entities
{
    // Maintenance Ticket Entity
    public class MaintenanceTicket
    {
        public int Id { get; set; }
        [Required]
        public string AircraftRegistration { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Status { get; set; } // e.g., "Open", "In Progress", "Resolved"
        public DateTime CreatedDate { get; set; }
        public DateTime? ResolvedDate { get; set; }

        // Reference to the MaintenanceLog that resolved this ticket
        public int? MaintenanceLogId { get; set; }
        public MaintenanceLog MaintenanceLog { get; set; }

        // Reference to TripLog ID that triggered the ticket
        public int? TripLogId { get; set; } 
    }
}
