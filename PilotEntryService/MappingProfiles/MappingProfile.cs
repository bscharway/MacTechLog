using AutoMapper;
using PilotEntryService.Models.DTOs;
using PilotEntryService.Models.Entities;

namespace PilotEntryService.MappingProfiles
{
    // AutoMapper Mapping Profile
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TripLog, FullTripLogDto>();
            CreateMap<CreateTripLogDto, TripLog>();
            CreateMap<De_Anti_IcingData, De_Anti_IcingDataDto>();
            CreateMap<CreateDe_Anti_IcingDataDto, De_Anti_IcingData>();
            CreateMap<FuelData, FuelDataDto>();
            CreateMap<CreateFuelDataDto, FuelData>();
            CreateMap<Inspection, InspectionDto>();
            CreateMap<CreateInspectionDto, Inspection>();
        }
    }
}
