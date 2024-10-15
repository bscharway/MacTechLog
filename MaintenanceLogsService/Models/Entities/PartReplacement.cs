using System.ComponentModel.DataAnnotations;

namespace MaintenanceLogsService.Models.Entities
{
    // Entity Model for PartReplacement
    public class PartReplacement
    {
        public int Id { get; set; }
        [Required]
        public string PartNumber { get; set; }
        public string SerialNumber { get; set; }
        public string BatchNumber { get; set; }
        public int MaintenanceLogId { get; set; }
        public MaintenanceLog MaintenanceLog { get; set; }
    }
}
