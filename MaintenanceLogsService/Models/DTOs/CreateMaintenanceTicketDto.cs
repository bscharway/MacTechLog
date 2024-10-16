namespace MaintenanceLogsService.Models.DTOs
{
    public class CreateMaintenanceTicketDto
    {
        public string AircraftRegistration { get; set; }
        public string Description { get; set; }
        public int? TripLogId { get; set; } // Link to the TripLog
    }
}
