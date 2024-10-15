namespace PilotEntryService.Models.DTOs
{
    // DTO for creating De_Anti_IcingData (without Id)
    public class CreateDe_Anti_IcingDataDto
    {
        public int FluidType { get; set; }
        public string MixtureRatio { get; set; }
        public TimeOnly? Time { get; set; }
    }
}
