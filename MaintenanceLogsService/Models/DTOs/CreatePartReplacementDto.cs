namespace MaintenanceLogsService.Models.DTOs
{
    // DTO for creating PartReplacement (without Id)
    public class CreatePartReplacementDto
    {
        public string PartNumber { get; set; }
        public string SerialNumber { get; set; }
        public string BatchNumber { get; set; }
    }
}
