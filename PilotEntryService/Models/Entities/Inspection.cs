namespace PilotEntryService.Models.Entities
{
    public class Inspection
    {
        public int Id { get; set; }
        public bool PreFlightInspectionCompleted { get; set; }
        public bool PostFlightInspectionCompleted { get; set; }
    }
}
