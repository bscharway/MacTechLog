using System.ComponentModel.DataAnnotations;

namespace MaintenanceLogsService.Models.Entities
{
    // Entity Model for DefectReport
    public class DefectReport
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsResolved { get; set; }
        public int MaintenanceLogId { get; set; }
        public MaintenanceLog MaintenanceLog { get; set; }
    }
}
