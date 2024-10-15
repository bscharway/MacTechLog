namespace MaintenanceLogsService.Models.DTOs
{
    // DTO for creating MaintenanceLog (without Id)
    public class CreateMaintenanceLogDto
    {
        public string AircraftRegistration { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string TechnicianId { get; set; }
        public string Description { get; set; }
        public string? MELReference { get; set; }
        public bool IsOperationalProcedure { get; set; }
        public bool IsRepetitive { get; set; }
        public CreateOilHydraulicFluidDataDto OilHydraulicFluidData { get; set; }
        public ICollection<CreateDefectReportDto> DefectReports { get; set; }
        public ICollection<CreatePartReplacementDto> PartReplacements { get; set; }
    }
}
