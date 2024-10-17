using System.ComponentModel.DataAnnotations;

namespace PilotEntryService.Models.Entities
{
    /// <summary>
    /// Represents de-anti icing data for a flight.
    /// </summary>
    public class De_Anti_IcingData
    {
        public int Id { get; set; }
        [Required]
        public int FluidType { get; set; }
        [Required]
        public string MixtureRatio { get; set; }
        public TimeOnly? Time { get; set; }
    }

    public enum FluideType
    {
        Type1 = 1,
        Type2 = 2,
        Type3 = 3,
        Type4 = 4
    }
}
