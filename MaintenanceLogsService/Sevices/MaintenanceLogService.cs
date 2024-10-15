using AutoMapper;
using MaintenanceLogsService.Models.DTOs;
using MaintenanceLogsService.Models.Entities;
using MaintenanceLogsService.Repository;

namespace MaintenanceLogsService.Sevices
{
    // Service Class for Business Logic
    public class MaintenanceLogService : IMaintenanceLogService
    {
        private readonly IMaintenanceLogRepository _repository;
        private readonly IMapper _mapper;

        public MaintenanceLogService(IMaintenanceLogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaintenanceLogDto>> GetAllMaintenanceLogsAsync()
        {
            var maintenanceLogs = await _repository.GetAllMaintenanceLogsAsync();
            return _mapper.Map<IEnumerable<MaintenanceLogDto>>(maintenanceLogs);
        }

        public async Task<MaintenanceLogDto> GetMaintenanceLogByIdAsync(int id)
        {
            var maintenanceLog = await _repository.GetMaintenanceLogByIdAsync(id);
            return _mapper.Map<MaintenanceLogDto>(maintenanceLog);
        }

        public async Task AddMaintenanceLogAsync(CreateMaintenanceLogDto maintenanceLogDto)
        {
            var maintenanceLog = _mapper.Map<MaintenanceLog>(maintenanceLogDto);
            await _repository.AddMaintenanceLogAsync(maintenanceLog);
        }

        public async Task UpdateMaintenanceLogAsync(int id, CreateMaintenanceLogDto maintenanceLogDto)
        {
            var maintenanceLog = await _repository.GetMaintenanceLogByIdAsync(id);
            if (maintenanceLog == null)
            {
                throw new KeyNotFoundException("MaintenanceLog not found");
            }

            _mapper.Map(maintenanceLogDto, maintenanceLog);
            await _repository.UpdateMaintenanceLogAsync(maintenanceLog);
        }

        public async Task DeleteMaintenanceLogAsync(int id)
        {
            await _repository.DeleteMaintenanceLogAsync(id);
        }
    }
}
