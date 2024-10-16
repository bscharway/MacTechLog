using AutoMapper;
using MaintenanceLogsService.Data;
using MaintenanceLogsService.Models.DTOs;
using MaintenanceLogsService.Models.Entities;
using MaintenanceLogsService.Repository;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceLogsService.Sevices
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
            return _mapper.Map<MaintenanceLogDto>(maintenanceLog);
        }

        public async Task AddMaintenanceLogAsync(CreateMaintenanceLogDto maintenanceLogDto)
        {
            var maintenanceLog = _mapper.Map<MaintenanceLog>(maintenanceLogDto);
            await _maintenanceLogRepository.AddMaintenanceLogAsync(maintenanceLog);

            // Check if there's an associated ticket
            if (maintenanceLogDto.MaintenanceTicketId.HasValue)
            {
                var ticket = await _maintenanceTicketRepository.GetMaintenanceTicketByIdAsync(maintenanceLogDto.MaintenanceTicketId.Value);
                if (ticket != null)
                {
                    ticket.Status = "Resolved";
                    ticket.ResolvedDate = DateTime.UtcNow;
                    await _maintenanceTicketRepository.UpdateMaintenanceTicketAsync(ticket);
                }
            }
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

        public async Task AddMaintenanceTicketAsync(CreateMaintenanceTicketDto ticketDto)
        {
            var ticket = _mapper.Map<MaintenanceTicket>(ticketDto);
            ticket.Status = "Open";
            ticket.CreatedDate = DateTime.UtcNow;
            await _maintenanceTicketRepository.AddMaintenanceTicketAsync(ticket);
        }

        public async Task UpdateMaintenanceTicketStatusAsync(int ticketId, string status)
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
        }

        public async Task<IEnumerable<MaintenanceTicketDto>> GetAllTicketsAsync()
        {
            var tickets = await _maintenanceTicketRepository.GetAllMaintenanceTicketsAsync();
            return _mapper.Map<IEnumerable<MaintenanceTicketDto>>(tickets);
        }
    }
}
