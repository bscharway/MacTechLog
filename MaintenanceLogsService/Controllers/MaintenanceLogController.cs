using AutoMapper;
using MaintenanceLogsService.Models.DTOs;
using MaintenanceLogsService.Sevices;
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
            await _service.AddMaintenanceLogAsync(maintenanceLogDto);
            return CreatedAtAction(nameof(GetMaintenanceLogById), new { id = maintenanceLogDto.AircraftRegistration }, maintenanceLogDto);
        }

        [HttpPut("logs/{id}")]
        public async Task<IActionResult> UpdateMaintenanceLog(int id, [FromBody] CreateMaintenanceLogDto maintenanceLogDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await _service.UpdateMaintenanceLogAsync(id, maintenanceLogDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
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
            catch (KeyNotFoundException)
            {
                return NotFound();
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
            await _service.AddMaintenanceTicketAsync(ticketDto);
            return Ok();
        }

        [HttpPut("tickets/{id}/status")]
        public async Task<IActionResult> UpdateMaintenanceTicketStatus(int id, [FromBody] string status)
        {
            try
            {
                await _service.UpdateMaintenanceTicketStatusAsync(id, status);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("tickets")]
        public async Task<IActionResult> GetAllTickets()
        {
            var tickets = await _service.GetAllTicketsAsync();
            return Ok(tickets);
        }
    }
}
