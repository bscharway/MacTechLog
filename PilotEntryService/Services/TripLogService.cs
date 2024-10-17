using AutoMapper;
using PilotEntryService.MessageBroker;
using PilotEntryService.Models.DTOs;
using PilotEntryService.Models.Entities;
using PilotEntryService.Repositories.Interfaces;
using PilotEntryService.Services.Interfaces;

namespace PilotEntryService.Services
{
    /// <summary>
    /// Service class for business logic related to TripLogs.
    /// </summary>
    public class TripLogService : ITripLogService
    {
        private readonly ITripLogRepository _tripLogRepository;
        private readonly TripLogPublisher _tripLogPublisher;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="TripLogService"/> class.
        /// </summary>
        /// <param name="tripLogRepository">The repository for TripLog entities.</param>
        /// <param name="tripLogPublisher">The publisher for TripLog messages.</param>
        /// <param name="mapper">The mapper for converting between entities and DTOs.</param>
        public TripLogService(ITripLogRepository tripLogRepository, TripLogPublisher tripLogPublisher, IMapper mapper)
        {
            _tripLogRepository = tripLogRepository;
            _tripLogPublisher = tripLogPublisher;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all TripLogs asynchronously.
        /// </summary>
        /// <returns>A collection of all TripLogs.</returns>
        public async Task<IEnumerable<FullTripLogDto>> GetAllTripLogsAsync()
        {
            var tripLogs = await _tripLogRepository.GetAllTripLogsAsync();
            return _mapper.Map<IEnumerable<FullTripLogDto>>(tripLogs);
        }

        /// <summary>
        /// Gets a specific TripLog by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the TripLog to retrieve.</param>
        /// <returns>The TripLog with the specified ID.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the TripLog is not found.</exception>
        public async Task<FullTripLogDto> GetTripLogByIdAsync(int id)
        {
            var tripLog = await _tripLogRepository.GetTripLogByIdAsync(id);
            if (tripLog == null)
            {
                throw new KeyNotFoundException("TripLog not found");
            }
            return _mapper.Map<FullTripLogDto>(tripLog);
        }

        /// <summary>
        /// Creates a new TripLog asynchronously.
        /// </summary>
        /// <param name="tripLogDto">The DTO containing the details of the TripLog to create.</param>
        public async Task CreateTripLogAsync(CreateTripLogDto tripLogDto)
        {
            var tripLog = _mapper.Map<TripLog>(tripLogDto);
            await _tripLogRepository.AddTripLogAsync(tripLog);

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

        /// <summary>
        /// Updates an existing TripLog asynchronously.
        /// </summary>
        /// <param name="id">The ID of the TripLog to update.</param>
        /// <param name="tripLogDto">The DTO containing the updated details of the TripLog.</param>
        /// <exception cref="KeyNotFoundException">Thrown when the TripLog is not found.</exception>
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

        /// <summary>
        /// Deletes a TripLog by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the TripLog to delete.</param>
        public async Task DeleteTripLogAsync(int id)
        {
            await _tripLogRepository.DeleteTripLogAsync(id);
        }
    }
}
