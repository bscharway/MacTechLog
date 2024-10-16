namespace MaintenanceLogsService.Models.DTOs
{
    // DTO for Maintenance Ticket
    public class MaintenanceTicketDto
    {
        public int Id { get; set; }
        public string AircraftRegistration { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ResolvedDate { get; set; }
        public int? MaintenanceLogId { get; set; }
        public int? TripLogId { get; set; } // Link to the TripLog
    }
}
