using AutoMapper;
using PilotEntryService.MessageBroker;
using PilotEntryService.Models.DTOs;
using PilotEntryService.Models.Entities;
using PilotEntryService.Repositories.Interfaces;
using PilotEntryService.Services.Interfaces;

namespace PilotEntryService.Services
{
    // Service Class for Business Logic
    public class TripLogService : ITripLogService
    {
        private readonly ITripLogRepository _tripLogRepository;
        private readonly TripLogPublisher _tripLogPublisher;
        private readonly IMapper _mapper;

        public TripLogService(ITripLogRepository tripLogRepository, TripLogPublisher tripLogPublisher, IMapper mapper)
        {
            _tripLogRepository = tripLogRepository;
            _tripLogPublisher = tripLogPublisher;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FullTripLogDto>> GetAllTripLogsAsync()
        {
            var tripLogs = await _tripLogRepository.GetAllTripLogsAsync();
            return _mapper.Map<IEnumerable<FullTripLogDto>>(tripLogs);
        }

        public async Task<FullTripLogDto> GetTripLogByIdAsync(int id)
        {
            var tripLog = await _tripLogRepository.GetTripLogByIdAsync(id);
            if (tripLog == null)
            {
                throw new KeyNotFoundException("TripLog not found");
            }
            return _mapper.Map<FullTripLogDto>(tripLog);
        }

        public async Task CreateTripLogAsync(CreateTripLogDto tripLogDto)
        {
            var tripLog = _mapper.Map<TripLog>(tripLogDto);
            await _tripLogRepository.AddTripLogAsync(tripLog);
            //await _tripLogRepository.SaveChangesAsync(); // Ensure changes are saved and tripLog.Id is generated

            // Retrieve the auto-generated TripLogId
            tripLog = await _tripLogRepository.GetTripLogByIdAsync(tripLog.Id);

            // Publish to RabbitMQ if there's a remark
            if (!string.IsNullOrEmpty(tripLog.Remarks))
            {
                var tripLogMessage = new TripLogMessage
                {
                    TripLogId = tripLog.Id,
                    AircraftRegistration = tripLog.AircraftRegistration,
                    Remark = tripLog.Remarks
                };

                _tripLogPublisher.PublishTripLog(tripLogMessage);
            }
        }

        public async Task UpdateTripLogAsync(int id, CreateTripLogDto tripLogDto)
        {
            var tripLog = await _tripLogRepository.GetTripLogByIdAsync(id);
            if (tripLog == null)
            {
                throw new KeyNotFoundException("TripLog not found");
            }

            _mapper.Map(tripLogDto, tripLog);
            await _tripLogRepository.UpdateTripLogAsync(tripLog);

            // Publish to RabbitMQ if there's a remark
            if (!string.IsNullOrEmpty(tripLog.Remarks))
            {
                var tripLogMessage = new TripLogMessage
                {
                    TripLogId = tripLog.Id,
                    AircraftRegistration = tripLog.AircraftRegistration,
                    Remark = tripLog.Remarks
                };

                _tripLogPublisher.PublishTripLog(tripLogMessage);
            }
        }

        public async Task DeleteTripLogAsync(int id)
        {
            await _tripLogRepository.DeleteTripLogAsync(id);
        }
    }
}
