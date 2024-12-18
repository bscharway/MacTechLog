﻿namespace PilotEntryService.Models.DTOs
{
    /// <summary>
    /// DTO for providing de and anti icing information for the current flight, if applicable 
    /// </summary>
    public class De_Anti_IcingDataDto
    {
        public int Id { get; set; }
        public int FluidType { get; set; }
        public string MixtureRatio { get; set; }
        public TimeOnly? Time { get; set; }
    }
}
