using AircraftService.Models.DTOs;
using AircraftService.Models.Entities;
using AircraftService.Repositories;
using AutoMapper;

namespace AircraftService.Services
{
    // Fuel Management Service Implementation
    public class FuelManagementService : IFuelManagementService
    {
        private readonly IFuelManagementRepository _fuelManagementRepository;
        private readonly IMapper _mapper;

        public FuelManagementService(IFuelManagementRepository fuelManagementRepository, IMapper mapper)
        {
            _fuelManagementRepository = fuelManagementRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FuelManagementDataDto>> GetAllFuelManagementDataAsync()
        {
            var fuelDataEntities = await _fuelManagementRepository.GetAllFuelManagementDataAsync();
            return _mapper.Map<IEnumerable<FuelManagementDataDto>>(fuelDataEntities);
        }

        public async Task<FuelManagementDataDto> GetFuelManagementDataByIdAsync(int id)
        {
            var fuelDataEntity = await _fuelManagementRepository.GetFuelManagementDataByIdAsync(id);
            return _mapper.Map<FuelManagementDataDto>(fuelDataEntity);
        }

        public async Task AddFuelManagementDataAsync(FuelManagementDataDto fuelManagementDataDto)
        {
            var fuelDataEntity = _mapper.Map<FuelManagementData>(fuelManagementDataDto);
            await _fuelManagementRepository.AddFuelManagementDataAsync(fuelDataEntity);
        }

        public async Task UpdateFuelManagementDataAsync(int id, FuelManagementDataDto fuelManagementDataDto)
        {
            var existingFuelData = await _fuelManagementRepository.GetFuelManagementDataByIdAsync(id);
            if (existingFuelData == null)
            {
                throw new KeyNotFoundException($"Fuel management data with ID {id} not found.");
            }

            var fuelDataEntity = _mapper.Map<FuelManagementData>(fuelManagementDataDto);
            fuelDataEntity.Id = existingFuelData.Id;
            await _fuelManagementRepository.UpdateFuelManagementDataAsync(fuelDataEntity);
        }

        public async Task DeleteFuelManagementDataAsync(int id)
        {
            await _fuelManagementRepository.DeleteFuelManagementDataAsync(id);
        }
    }
}
