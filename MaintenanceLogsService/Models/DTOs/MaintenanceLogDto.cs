namespace MaintenanceLogsService.Models.DTOs
{
    // DTO for MaintenanceLog
    public class MaintenanceLogDto
    {
        public int Id { get; set; }
        public string AircraftRegistration { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string TechnicianId { get; set; }
        public string Description { get; set; }
        public string? MELReference { get; set; }
        public bool IsOperationalProcedure { get; set; }
        public bool IsRepetitive { get; set; }
        public OilHydraulicFluidDataDto OilHydraulicFluidData { get; set; }
        public ICollection<DefectReportDto> DefectReports { get; set; }
        public ICollection<PartReplacementDto> PartReplacements { get; set; }
    }

}
