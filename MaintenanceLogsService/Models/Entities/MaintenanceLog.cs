using System.ComponentModel.DataAnnotations;

namespace MaintenanceLogsService.Models.Entities
{
    public class MaintenanceLog
    {
        public int Id { get; set; }
        [Required]
        public string AircraftRegistration { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string TechnicianId { get; set; }
        public string Description { get; set; }
        public string? MELReference { get; set; }
        public bool IsOperationalProcedure { get; set; }
        public bool IsRepetitive { get; set; }
        public int? OilHydraulicFluidDataId { get; set; }
        public OilHydraulicFluidData? OilHydraulicFluidData { get; set; }
        public ICollection<DefectReport> DefectReports { get; set; }
        public ICollection<PartReplacement> PartReplacements { get; set; }
    }
}
