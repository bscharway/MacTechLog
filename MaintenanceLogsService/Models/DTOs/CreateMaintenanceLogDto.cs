using System.ComponentModel.DataAnnotations;

namespace MaintenanceLogsService.Models.DTOs
{
    // DTO for creating MaintenanceLog (without Id)
    public class CreateMaintenanceLogDto
    {
        [Required]
        public string AircraftRegistration { get; set; }

        [Required]
        public DateTime MaintenanceDate { get; set; }

        [Required]
        public string TechnicianId { get; set; }

        public string Description { get; set; }
        public string? MELReference { get; set; }
        public bool IsOperationalProcedure { get; set; }
        public bool IsRepetitive { get; set; }

        public CreateOilHydraulicFluidDataDto OilHydraulicFluidData { get; set; }

        public ICollection<CreateDefectReportDto> DefectReports { get; set; } = new List<CreateDefectReportDto>();
        public ICollection<CreatePartReplacementDto> PartReplacements { get; set; } = new List<CreatePartReplacementDto>();

        // List of ticket IDs to be resolved by this maintenance log
        public ICollection<int> MaintenanceTicketIds { get; set; } = new List<int>();
    }
}
