using AutoMapper;
using MaintenanceLogsService.Models.DTOs;
using MaintenanceLogsService.Models.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MaintenanceLogsService.MappingProfiles
{
    // AutoMapper Mapping Profile
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MaintenanceLog, MaintenanceLogDto>();
            CreateMap<CreateMaintenanceLogDto, MaintenanceLog>();
            CreateMap<DefectReport, DefectReportDto>();
            CreateMap<CreateDefectReportDto, DefectReport>();
            CreateMap<PartReplacement, PartReplacementDto>();
            CreateMap<CreatePartReplacementDto, PartReplacement>();
            CreateMap<OilHydraulicFluidData, OilHydraulicFluidDataDto>();
            CreateMap<CreateOilHydraulicFluidDataDto, OilHydraulicFluidData>();
        }
    }

}
