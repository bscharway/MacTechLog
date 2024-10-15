namespace PilotEntryService.Models.DTOs
{
    public class InspectionDto
    {
        public int Id { get; set; }
        public bool PreFlightInspectionCompleted { get; set; }
        public bool PostFlightInspectionCompleted { get; set; }
    }
}
