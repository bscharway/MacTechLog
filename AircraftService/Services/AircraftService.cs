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

        public async Task<AircraftDto> GetAircraftByIdAsync(string aircraftRegistration)
        {
            var aircraft = await _aircraftRepository.GetAircraftByIdAsync(aircraftRegistration);
            if (aircraft == null)
            {
                throw new KeyNotFoundException($"Aircraft with ID {aircraftRegistration} not found.");
            }
            return _mapper.Map<AircraftDto>(aircraft);
        }

        public async Task<AircraftDto> AddAircraftAsync(CreateAircraftDto createAircraftDto)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var aircraft = _mapper.Map<Aircraft>(createAircraftDto);

                // Handle FuelManagementData initialization
                //aircraft.FuelManagementData = _mapper.Map<FuelManagementData>(createAircraftDto.FuelManagementDataDto);

                await _aircraftRepository.AddAircraftAsync(aircraft);
                //await _fuelManagementRepository.AddFuelManagementDataAsync(aircraft.FuelManagementData);

                scope.Complete();

                return _mapper.Map<AircraftDto>(aircraft);
            }
        }

        public async Task UpdateAircraftAsync(string aircraftRegistration, UpdateAircraftDto updateAircraftDto)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var aircraft = await _aircraftRepository.GetAircraftByIdAsync(aircraftRegistration);
                if (aircraft == null)
                {
                    throw new KeyNotFoundException($"Aircraft with ID {aircraftRegistration} not found.");
                }

                // Update the aircraft details
                _mapper.Map(updateAircraftDto, aircraft);

                //// Update the FuelManagementData if provided
                //if (updateAircraftDto.FuelManagementDataDto != null)
                //{
                //    if (aircraft.FuelManagementData == null)
                //    {
                //        aircraft.FuelManagementData = new FuelManagementData();
                //    }
                //    _mapper.Map(updateAircraftDto.FuelManagementDataDto, aircraft.FuelManagementData);
                //    await _fuelManagementRepository.UpdateFuelManagementDataAsync(aircraft.FuelManagementData);
                //}

                await _aircraftRepository.UpdateAircraftAsync(aircraft);

                scope.Complete();
            }
        }

        public async Task DeleteAircraftAsync(string id)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                // Delete related fuel management data
                var fuelManagementData = await _fuelManagementRepository.GetFuelManagementDataByAircraftIdAsync(id);
                if (fuelManagementData != null)
                {
                    await _fuelManagementRepository.DeleteFuelManagementDataAsync(fuelManagementData.Id);
                }

                await _aircraftRepository.DeleteAircraftAsync(id);
                scope.Complete();
            }
        }
        //public async Task DeleteAircraftAsync(int id)
        //{
        //    using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        //    {
        //        await _aircraftRepository.DeleteAircraftAsync(id);
        //        scope.Complete();
        //    }
        //}

        public async Task UpdateFuelManagementAsync(string aircraftRegistration, UpdateFuelManagementDto fuelManagementDto)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var fuelManagementData = await _fuelManagementRepository.GetFuelManagementDataByAircraftIdAsync(aircraftRegistration);
                if (fuelManagementData == null)
                {
                    throw new KeyNotFoundException($"Fuel management data for Aircraft ID {aircraftRegistration} not found.");
                }

                // Update fuel management details
                _mapper.Map(fuelManagementDto, fuelManagementData);
                await _fuelManagementRepository.UpdateFuelManagementDataAsync(fuelManagementData);

                scope.Complete();
            }
        }

        //public async Task UpdateFuelManagementAsync(int id, UpdateFuelManagementDto fuelManagementDto)
        //{
        //    using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        //    {
        //        var aircraft = await _aircraftRepository.GetAircraftByIdAsync(id);
        //        if (aircraft == null)
        //        {
        //            throw new KeyNotFoundException($"Aircraft with ID {id} not found.");
        //        }

        //        if (aircraft.FuelManagementData != null)
        //        {
        //            aircraft.FuelManagementData.RevisedParkingFuel = fuelManagementDto.RevisedParkingFuel;
        //            aircraft.FuelManagementData.PlannedUplift = fuelManagementDto.PlannedUplift;
        //            aircraft.FuelManagementData.ActualUplift = fuelManagementDto?.ActualUplift;
        //            aircraft.FuelManagementData.LandingFuel = fuelManagementDto.LandingFuel;
        //        }
        //        else
        //        {
        //            // Create FuelManagementData if it doesn't exist
        //            aircraft.FuelManagementData = new FuelManagementData
        //            {
        //                RevisedParkingFuel = fuelManagementDto.RevisedParkingFuel,
        //                PlannedUplift = fuelManagementDto.PlannedUplift,
        //                ActualUplift = fuelManagementDto?.ActualUplift,
        //                LandingFuel = fuelManagementDto.LandingFuel
        //            };
        //            await _fuelManagementRepository.AddFuelManagementDataAsync(aircraft.FuelManagementData);
        //        }

        //        await _aircraftRepository.UpdateAircraftAsync(aircraft);

        //        scope.Complete();
        //    }
        //}



        // Aircraft Service Implementation for Flight Hours and Cycles Tracking
        public async Task UpdateFlightHoursAndCyclesAsync(string aircraftId, int additionalHours, int additionalCycles)
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

        public async Task UpdateFlightHoursCyclesAndFuelAsync(string aircraftId, int flightHours, int cycles, double fuelConsumed)
        {
            var aircraft = await _aircraftRepository.GetAircraftByIdAsync(aircraftId);
            if (aircraft == null)
            {
                throw new KeyNotFoundException($"Aircraft with ID {aircraftId} not found.");
            }

            // Update flight hours and cycles
            aircraft.TotalFlightHours += flightHours;
            aircraft.Cycles += cycles;

            // Update fuel management data
            var fuelManagementData = await _fuelManagementRepository.GetFuelManagementDataByAircraftIdAsync(aircraftId);
            if (fuelManagementData != null)
            {
                fuelManagementData.LatestRecordedFuelOnBoard -= fuelConsumed;
                if (fuelManagementData.LatestRecordedFuelOnBoard < 0)
                {
                    fuelManagementData.LatestRecordedFuelOnBoard = 0; // Ensure fuel on board is not negative
                }
                await _fuelManagementRepository.UpdateFuelManagementDataAsync(fuelManagementData);
            }

            await _aircraftRepository.UpdateAircraftAsync(aircraft);
        }

        //public async Task UpdateFlightHoursCyclesAndFuelAsync(int aircraftId, int flightHours, int cycles, int fuelConsumed)
        //{
        //    var aircraft = await _aircraftRepository.GetAircraftByIdAsync(aircraftId);
        //    if (aircraft == null)
        //    {
        //        throw new KeyNotFoundException($"Aircraft with ID {aircraftId} not found.");
        //    }

        //    // Update flight hours and cycles
        //    aircraft.TotalFlightHours += flightHours;
        //    aircraft.Cycles += cycles;

        //    // Update fuel management data
        //    if (aircraft.FuelManagementData != null)
        //    {
        //        aircraft.FuelManagementData.LatestRecordedFuelOnBoard -= fuelConsumed;
        //        if (aircraft.FuelManagementData.LatestRecordedFuelOnBoard < 0)
        //        {
        //            aircraft.FuelManagementData.LatestRecordedFuelOnBoard = 0; // Ensure fuel on board is not negative
        //        }
        //    }

        //    await _aircraftRepository.UpdateAircraftAsync(aircraft);
        //    await _fuelManagementRepository.AddFuelManagementDataAsync(aircraft.FuelManagementData);
        //}

        public async Task UpdateFlightHoursCyclesAndFuelAsyncFromMessageBroker(string aircraftId, int flightHours, int cycles, double landingFuel, int tripLogId = 0, int maintenanceLogId = 0)
        {
            var aircraft = await _aircraftRepository.GetAircraftByIdAsync(aircraftId);
            if (aircraft == null)
            {
                throw new KeyNotFoundException($"Aircraft with ID {aircraftId} not found.");
            }

            // Update flight hours and cycles
            aircraft.TotalFlightHours += flightHours;
            aircraft.Cycles += cycles;

            // Create a new FuelManagementData entry
            var fuelManagementData = new FuelManagementData
            {
                AircraftRegistration = aircraftId,
                LandingFuel = landingFuel,
                TripLogId = tripLogId,
                MaintenanceLogId = maintenanceLogId,
                LatestRecordedFuelOnBoard = landingFuel
            };

            await _fuelManagementRepository.AddFuelManagementDataAsync(fuelManagementData);
            await _aircraftRepository.UpdateAircraftAsync(aircraft);
        }

    }
}
