using System.ComponentModel.DataAnnotations;

namespace MaintenanceLogsService.Models.Entities
{
    public class MaintenanceLog
    {
        public int Id { get; set; }
        [Required]
        public string AircraftRegistration { get; set; }
        public DateTime MaintenanceDate { get; set; }
        [Required]
        public string TechnicianId { get; set; }
        [Required]
        public string Description { get; set; }
        public string? MELReference { get; set; }
        public bool IsOperationalProcedure { get; set; }
        public bool IsRepetitive { get; set; }
        public int? OilHydraulicFluidDataId { get; set; }
        public OilHydraulicFluidData? OilHydraulicFluidData { get; set; }

        //Added default initialization for collection properties
        //(DefectReports, PartReplacements, ResolvedTickets) to prevent null reference issues.
        
        // Navigation property to represent related defect reports
        public ICollection<DefectReport> DefectReports { get; set; } = new List<DefectReport>();
        // Navigation property to represent related part replacements
        public ICollection<PartReplacement> PartReplacements { get; set; } = new List<PartReplacement>();

        // Navigation property to represent related tickets
        public ICollection<MaintenanceTicket> ResolvedTickets { get; set; } = new List<MaintenanceTicket>();
    }
}
