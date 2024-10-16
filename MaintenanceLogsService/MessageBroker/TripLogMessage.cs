namespace MaintenanceLogsService.MessageBroker
{
    // Sample message from RabbitMQ
    public class TripLogMessage
    {
        public int TripLogId { get; set; }
        public string AircraftRegistration { get; set; }
        public string Remark { get; set; }
    }
}
