using AutoMapper;
using MaintenanceLogsService.Models.DTOs;
using MaintenanceLogsService.Models.Entities;

namespace MaintenanceLogsService.MappingProfiles
{
    // AutoMapper Mapping Profile
    public class MappingProfile : Profile
    {
        public class MaintenanceLogsMappingProfile : Profile
        {
            public MaintenanceLogsMappingProfile()
            {
                // Mapping for MaintenanceTicket
                CreateMap<CreateMaintenanceTicketDto, MaintenanceTicket>();
                CreateMap<MaintenanceTicket, MaintenanceTicketDto>();

                // Mapping for MaintenanceLog
                CreateMap<CreateMaintenanceLogDto, MaintenanceLog>();
                CreateMap<MaintenanceLog, MaintenanceLogDto>();

                // Mapping for OilHydraulicFluidData
                CreateMap<CreateOilHydraulicFluidDataDto, OilHydraulicFluidData>();
                CreateMap<OilHydraulicFluidData, OilHydraulicFluidDataDto>();

                // Mapping for DefectReport
                CreateMap<CreateDefectReportDto, DefectReport>();
                CreateMap<DefectReport, DefectReportDto>();

                // Mapping for PartReplacement
                CreateMap<CreatePartReplacementDto, PartReplacement>();
                CreateMap<PartReplacement, PartReplacementDto>();
            }
        }

    }
}
