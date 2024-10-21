using AutoMapper;
using MaintenanceLogsService.Models.DTOs;
using MaintenanceLogsService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaintenanceLogsService.Controllers
{
    // Maintenance Log Controller
    [ApiController]
    [Route("api/[controller]")]
    public class MaintenanceLogController : ControllerBase
    {
        private readonly IMaintenanceLogService _service;
        private readonly IMapper _mapper;

        public MaintenanceLogController(IMaintenanceLogService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("logs")]
        public async Task<IActionResult> GetAllMaintenanceLogs()
        {
            var logs = await _service.GetAllMaintenanceLogsAsync();
            return Ok(logs);
        }

        [HttpGet("logs/{id}")]
        public async Task<IActionResult> GetMaintenanceLogById(int id)
        {
            var log = await _service.GetMaintenanceLogByIdAsync(id);
            if (log == null)
            {
                return NotFound();
            }
            return Ok(log);
        }

        [HttpPost("logs")]
        public async Task<IActionResult> AddMaintenanceLog([FromBody] CreateMaintenanceLogDto maintenanceLogDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var createdLog = await _service.AddMaintenanceLogAsync(maintenanceLogDto);
                return CreatedAtAction(nameof(GetMaintenanceLogById), new { id = createdLog.Id }, createdLog);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPut("logs/{id}")]
        public async Task<IActionResult> UpdateMaintenanceLog(int id, [FromBody] CreateMaintenanceLogDto maintenanceLogDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _service.UpdateMaintenanceLogAsync(id, maintenanceLogDto);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            return NoContent();
        }

        [HttpDelete("logs/{id}")]
        public async Task<IActionResult> DeleteMaintenanceLog(int id)
        {
            try
            {
                await _service.DeleteMaintenanceLogAsync(id);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            return NoContent();
        }

        [HttpPost("tickets")]
        public async Task<IActionResult> AddMaintenanceTicket([FromBody] CreateMaintenanceTicketDto ticketDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdTicket = await _service.AddMaintenanceTicketAsync(ticketDto);
            return CreatedAtAction(nameof(GetMaintenanceTicketById), new { id = createdTicket.Id }, createdTicket);
        }

        [HttpPut("tickets/{id}/status")]
        public async Task<IActionResult> UpdateMaintenanceTicketStatus(int id, [FromBody] string status)
        {
            try
            {
                var updatedTicket = await _service.UpdateMaintenanceTicketStatusAsync(id, status);
                return Ok(updatedTicket);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet("tickets")]
        public async Task<IActionResult> GetAllTickets()
        {
            var tickets = await _service.GetAllTicketsAsync();
            return Ok(tickets);
        }

        [HttpGet("tickets/{id}")]
        public async Task<IActionResult> GetMaintenanceTicketById(int id)
        {
            var ticket = await _service.GetMaintenanceTicketByIdAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }
    }
}
