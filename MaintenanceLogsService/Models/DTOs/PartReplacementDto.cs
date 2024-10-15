namespace MaintenanceLogsService.Models.DTOs
{
    // DTO for PartReplacement
    public class PartReplacementDto
    {
        public int Id { get; set; }
        public string PartNumber { get; set; }
        public string SerialNumber { get; set; }
        public string BatchNumber { get; set; }
    }
}
