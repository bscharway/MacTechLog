namespace PilotEntryService.Models.DTOs
{
    // DTO for creating Inspection (without Id)
    public class CreateInspectionDto
    {
        public bool PreFlightInspectionCompleted { get; set; }
        public bool PostFlightInspectionCompleted { get; set; }
    }

}
