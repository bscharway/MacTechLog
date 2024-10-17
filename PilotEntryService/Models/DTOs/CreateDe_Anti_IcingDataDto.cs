namespace PilotEntryService.Models.DTOs
{
    /// <summary>
    /// DTO for creating De_Anti_IcingData (without Id) for the current flight 
    /// </summary>
    public class CreateDe_Anti_IcingDataDto
    {
        public int FluidType { get; set; }
        public required string MixtureRatio { get; set; }
        public TimeOnly? Time { get; set; }
    }
}
