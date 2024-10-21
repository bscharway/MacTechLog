using AircraftService.Models.DTOs;
using AircraftService.Models.Entities;
using AircraftService.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Transactions;

namespace AircraftService.Services
{
    // Service Class for Business Logic
    public class AircraftService : IAircraftService
    {
        private readonly IAircraftRepository _aircraftRepository;
        private readonly IFuelManagementRepository _fuelManagementRepository;
        private readonly IMapper _mapper;

        public AircraftService(IAircraftRepository aircraftRepository, IFuelManagementRepository fuelManagementRepository, IMapper mapper)
        {
            _aircraftRepository = aircraftRepository;
            _fuelManagementRepository = fuelManagementRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AircraftDto>> GetAllAircraftAsync()
        {
            var aircrafts = await _aircraftRepository.GetAllAircraftsAsync();
            return _mapper.Map<IEnumerable<AircraftDto>>(aircrafts);
        }

        public async Task<AircraftDto> GetAircraftByIdAsync(int id)
        {
            var aircraft = await _aircraftRepository.GetAircraftByIdAsync(id);
            if (aircraft == null)
            {
                throw new KeyNotFoundException($"Aircraft with ID {id} not found.");
            }
            return _mapper.Map<AircraftDto>(aircraft);
        }

        public async Task<AircraftDto> AddAircraftAsync(CreateAircraftDto createAircraftDto)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var aircraft = _mapper.Map<Aircraft>(createAircraftDto);

                // Handle FuelManagementData initialization
                aircraft.FuelManagementData = _mapper.Map<FuelManagementData>(createAircraftDto.FuelManagementDataDto);

                await _aircraftRepository.AddAircraftAsync(aircraft);
                await _fuelManagementRepository.AddFuelManagementDataAsync(aircraft.FuelManagementData);

                scope.Complete();

                return _mapper.Map<AircraftDto>(aircraft);
            }
        }

        public async Task UpdateAircraftAsync(int id, UpdateAircraftDto updateAircraftDto)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var aircraft = await _aircraftRepository.GetAircraftByIdAsync(id);
                if (aircraft == null)
                {
                    throw new KeyNotFoundException($"Aircraft with ID {id} not found.");
                }

                // Update the aircraft details
                _mapper.Map(updateAircraftDto, aircraft);

                // Update the FuelManagementData if provided
                if (updateAircraftDto.FuelManagementDataDto != null)
                {
                    if (aircraft.FuelManagementData == null)
                    {
                        aircraft.FuelManagementData = new FuelManagementData();
                    }
                    _mapper.Map(updateAircraftDto.FuelManagementDataDto, aircraft.FuelManagementData);
                    await _fuelManagementRepository.UpdateFuelManagementDataAsync(aircraft.FuelManagementData);
                }

                await _aircraftRepository.UpdateAircraftAsync(aircraft);

                scope.Complete();
            }
        }

        public async Task DeleteAircraftAsync(int id)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _aircraftRepository.DeleteAircraftAsync(id);
                scope.Complete();
            }
        }

        public async Task UpdateFuelManagementAsync(int id, UpdateFuelManagementDto fuelManagementDto)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var aircraft = await _aircraftRepository.GetAircraftByIdAsync(id);
                if (aircraft == null)
                {
                    throw new KeyNotFoundException($"Aircraft with ID {id} not found.");
                }

                if (aircraft.FuelManagementData != null)
                {
                    aircraft.FuelManagementData.FuelOnBoard = fuelManagementDto.FuelOnBoard;
                    aircraft.FuelManagementData.FuelCapacity = fuelManagementDto.FuelCapacity;
                }
                else
                {
                    // Create FuelManagementData if it doesn't exist
                    aircraft.FuelManagementData = new FuelManagementData
                    {
                        FuelOnBoard = fuelManagementDto.FuelOnBoard,
                        FuelCapacity = fuelManagementDto.FuelCapacity
                    };
                    await _fuelManagementRepository.AddFuelManagementDataAsync(aircraft.FuelManagementData);
                }

                await _aircraftRepository.UpdateAircraftAsync(aircraft);

                scope.Complete();
            }
        }

        // Aircraft Service Implementation for Flight Hours and Cycles Tracking
        public async Task UpdateFlightHoursAndCyclesAsync(int aircraftId, int additionalHours, int additionalCycles)
        {
            var aircraft = await _aircraftRepository.GetAircraftByIdAsync(aircraftId);
            if (aircraft == null)
            {
                throw new KeyNotFoundException($"Aircraft with ID {aircraftId} not found.");
            }

            aircraft.TotalFlightHours += additionalHours;
            aircraft.Cycles += additionalCycles;

            await _aircraftRepository.UpdateAircraftAsync(aircraft);
        }

    }
}
