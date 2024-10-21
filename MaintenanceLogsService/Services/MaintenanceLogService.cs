using AutoMapper;
using MaintenanceLogsService.Models.DTOs;
using MaintenanceLogsService.Models.Entities;
using MaintenanceLogsService.Repository;

namespace MaintenanceLogsService.Services
{
    // Service Class for Business Logic
    public class MaintenanceLogService : IMaintenanceLogService
    {
        private readonly IMaintenanceLogRepository _maintenanceLogRepository;
        private readonly IMaintenanceTicketRepository _maintenanceTicketRepository;
        private readonly IMapper _mapper;

        public MaintenanceLogService(IMaintenanceLogRepository maintenanceLogRepository, IMaintenanceTicketRepository maintenanceTicketRepository, IMapper mapper)
        {
            _maintenanceLogRepository = maintenanceLogRepository;
            _maintenanceTicketRepository = maintenanceTicketRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaintenanceLogDto>> GetAllMaintenanceLogsAsync()
        {
            var maintenanceLogs = await _maintenanceLogRepository.GetAllMaintenanceLogsAsync();
            return _mapper.Map<IEnumerable<MaintenanceLogDto>>(maintenanceLogs);
        }

        public async Task<MaintenanceLogDto> GetMaintenanceLogByIdAsync(int id)
        {
            var maintenanceLog = await _maintenanceLogRepository.GetMaintenanceLogByIdAsync(id);
            if (maintenanceLog == null)
            {
                throw new KeyNotFoundException("MaintenanceLog not found");
            }
            return _mapper.Map<MaintenanceLogDto>(maintenanceLog);
        }

        public async Task<MaintenanceLogDto> AddMaintenanceLogAsync(CreateMaintenanceLogDto maintenanceLogDto)
        {
            var maintenanceLog = _mapper.Map<MaintenanceLog>(maintenanceLogDto);

            // Validate associated tickets
            if (maintenanceLogDto.MaintenanceTicketIds != null && maintenanceLogDto.MaintenanceTicketIds.Any())
            {
                var tickets = await _maintenanceTicketRepository.GetMaintenanceTicketsByIdsAsync(maintenanceLogDto.MaintenanceTicketIds);
                if (tickets.Count != maintenanceLogDto.MaintenanceTicketIds.Count)
                {
                    throw new KeyNotFoundException("One or more MaintenanceTickets were not found");
                }
                foreach (var ticket in tickets)
                {
                    ticket.Status = "Resolved";
                    ticket.ResolvedDate = DateTime.UtcNow;
                }
                await _maintenanceTicketRepository.UpdateMaintenanceTicketsAsync(tickets);
            }

            await _maintenanceLogRepository.AddMaintenanceLogAsync(maintenanceLog);
            return _mapper.Map<MaintenanceLogDto>(maintenanceLog);
        }

        public async Task UpdateMaintenanceLogAsync(int id, CreateMaintenanceLogDto maintenanceLogDto)
        {
            var maintenanceLog = await _maintenanceLogRepository.GetMaintenanceLogByIdAsync(id);
            if (maintenanceLog == null)
            {
                throw new KeyNotFoundException("MaintenanceLog not found");
            }
            _mapper.Map(maintenanceLogDto, maintenanceLog);
            await _maintenanceLogRepository.UpdateMaintenanceLogAsync(maintenanceLog);
        }

        public async Task DeleteMaintenanceLogAsync(int id)
        {
            await _maintenanceLogRepository.DeleteMaintenanceLogAsync(id);
        }

        public async Task<MaintenanceTicketDto> AddMaintenanceTicketAsync(CreateMaintenanceTicketDto ticketDto)
        {
            var ticket = _mapper.Map<MaintenanceTicket>(ticketDto);
            ticket.Status = "Open";
            ticket.CreatedDate = DateTime.UtcNow;
            await _maintenanceTicketRepository.AddMaintenanceTicketAsync(ticket);
            return _mapper.Map<MaintenanceTicketDto>(ticket);
        }

        public async Task<MaintenanceTicketDto> UpdateMaintenanceTicketStatusAsync(int ticketId, string status)
        {
            var ticket = await _maintenanceTicketRepository.GetMaintenanceTicketByIdAsync(ticketId);
            if (ticket == null)
            {
                throw new KeyNotFoundException("Ticket not found");
            }
            ticket.Status = status;
            if (status == "Resolved")
            {
                ticket.ResolvedDate = DateTime.UtcNow;
            }
            await _maintenanceTicketRepository.UpdateMaintenanceTicketAsync(ticket);
            return _mapper.Map<MaintenanceTicketDto>(ticket);
        }

        public async Task<IEnumerable<MaintenanceTicketDto>> GetAllTicketsAsync()
        {
            var tickets = await _maintenanceTicketRepository.GetAllMaintenanceTicketsAsync();
            return _mapper.Map<IEnumerable<MaintenanceTicketDto>>(tickets);
        }

        public async Task<MaintenanceTicketDto> GetMaintenanceTicketByIdAsync(int id)
        {
            var ticket = await _maintenanceTicketRepository.GetMaintenanceTicketByIdAsync(id);
            if (ticket == null)
            {
                throw new KeyNotFoundException("Ticket not found");
            }
            return _mapper.Map<MaintenanceTicketDto>(ticket);
        }
    }
}
