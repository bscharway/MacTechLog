namespace MaintenanceLogsService.Models.DTOs
{
    // DTO for DefectReport
    public class DefectReportDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsResolved { get; set; }
    }
}
