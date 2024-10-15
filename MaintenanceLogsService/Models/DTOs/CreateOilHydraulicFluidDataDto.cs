namespace MaintenanceLogsService.Models.DTOs
{
    // DTO for creating OilHydraulicFluidData (without Id)
    public class CreateOilHydraulicFluidDataDto
    {
        public double? APUOilAdded { get; set; }
        public double? LeftHandEngineOilAdded { get; set; }
        public double? RightHandEngineOilAdded { get; set; }
        public double? LeftHandHydraulicSystemFluidAdded { get; set; }
        public double? RightHandHydraulicSystemFluidAdded { get; set; }
        public double? CenterHydraulicSystemFluidAdded { get; set; }
    }
}
