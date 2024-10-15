namespace MaintenanceLogsService.Models.DTOs
{
    // DTO for creating DefectReport (without Id)
    public class CreateDefectReportDto
    {
        public string Description { get; set; }
        public bool IsResolved { get; set; }
    }
}
