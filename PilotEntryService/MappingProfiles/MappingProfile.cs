using AutoMapper;
using PilotEntryService.Models.DTOs;
using PilotEntryService.Models.Entities;

namespace PilotEntryService.MappingProfiles
{
    /// <summary>
    /// AutoMapper Mapping Profile for converting between entities and DTOs.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// Configures the mapping between entities and DTOs.
        /// </summary>
        public MappingProfile()
        {
            // Mapping configurations for TripLog and its DTOs
            CreateMap<TripLog, FullTripLogDto>();
            CreateMap<CreateTripLogDto, TripLog>();

            // Mapping configurations for De_Anti_IcingData and its DTOs
            CreateMap<De_Anti_IcingData, De_Anti_IcingDataDto>();
            CreateMap<CreateDe_Anti_IcingDataDto, De_Anti_IcingData>();

            // Mapping configurations for FuelData and its DTOs
            //CreateMap<FuelData, FuelDataDto>();
            //CreateMap<CreateFuelDataDto, FuelData>();

            //// Mapping configurations for Inspection and its DTOs
            //CreateMap<Inspection, InspectionDto>();
            //CreateMap<CreateInspectionDto, Inspection>();
        }
    }
}
