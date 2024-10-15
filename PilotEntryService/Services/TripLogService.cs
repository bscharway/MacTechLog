using AutoMapper;
using PilotEntryService.Models.DTOs;
using PilotEntryService.Models.Entities;
using PilotEntryService.Repositories.Interfaces;
using PilotEntryService.Services.Interfaces;

namespace PilotEntryService.Services
{
    // Service Class for Business Logic
    public class TripLogService : ITripLogService
    {
        private readonly ITripLogRepository _repository;
        private readonly IMapper _mapper;

        public TripLogService(ITripLogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FullTripLogDto>> GetAllTripLogsAsync()
        {
            var tripLogs = await _repository.GetAllTripLogsAsync();
            return _mapper.Map<IEnumerable<FullTripLogDto>>(tripLogs);
        }

        public async Task<FullTripLogDto> GetTripLogByIdAsync(int id)
        {
            var tripLog = await _repository.GetTripLogByIdAsync(id);
            return _mapper.Map<FullTripLogDto>(tripLog);
        }

        public async Task AddTripLogAsync(CreateTripLogDto tripLogDto)
        {
            var tripLog = _mapper.Map<TripLog>(tripLogDto);
            await _repository.AddTripLogAsync(tripLog);
        }

        public async Task UpdateTripLogAsync(int id, CreateTripLogDto tripLogDto)
        {
            var tripLog = await _repository.GetTripLogByIdAsync(id);
            if (tripLog == null)
            {
                throw new KeyNotFoundException("TripLog not found");
            }

            _mapper.Map(tripLogDto, tripLog);
            await _repository.UpdateTripLogAsync(tripLog);
        }

        public async Task DeleteTripLogAsync(int id)
        {
            await _repository.DeleteTripLogAsync(id);
        }
    }
}
