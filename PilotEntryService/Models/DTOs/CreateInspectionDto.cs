namespace PilotEntryService.Models.DTOs
{
    /// <summary>
    /// DTO for creating Inspection (without Id) for the current flight 
    /// </summary>
    public class CreateInspectionDto
    {
        public bool PreFlightInspectionCompleted { get; set; }
        public bool PostFlightInspectionCompleted { get; set; }
    }

}
