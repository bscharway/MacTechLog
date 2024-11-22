using AutoMapper;
using AircraftService.Models.DTOs;
using AircraftService.Models.Entities;

namespace AircraftService.MappingProfiles
{
    // AutoMapper Mapping Profile for AircraftService
    public class AircraftMappingProfile : Profile
    {
        public AircraftMappingProfile()
        {
            // Mapping from Aircraft entity to AircraftDto
            CreateMap<Aircraft, AircraftDto>();
            //.ForMember(dest => dest.FuelManagement, opt => opt.MapFrom(src => src.FuelManagementData));

            // Mapping from CreateAircraftDto to Aircraft entity
            CreateMap<CreateAircraftDto, Aircraft>();
                //.ForMember(dest => dest.FuelManagementData, opt => opt.MapFrom(src => src.FuelManagementDataDto));

            // Mapping from UpdateAircraftDto to Aircraft entity
            CreateMap<UpdateAircraftDto, Aircraft>();

            // Mapping from FuelManagementData to FuelManagementDataDto
            CreateMap<FuelManagementData, FuelManagementDataDto>();

            // Mapping from FuelManagementDataDto to FuelManagementData
            CreateMap<FuelManagementDataDto, FuelManagementData>();

                //.ForMember(dest => dest.AircraftId, opt => opt.MapFrom(src => src.)); // Ignore Id to avoid conflicts when creating a new FuelManagementData
        }
    }
}
