using AutoMapper;
using MaintenanceLogsService.Models.DTOs;
using MaintenanceLogsService.Sevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaintenanceLogsService.Controllers
{
    // API Controller
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

        [HttpGet]
        public async Task<IActionResult> GetAllMaintenanceLogs()
        {
            var maintenanceLogs = await _service.GetAllMaintenanceLogsAsync();
            return Ok(maintenanceLogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaintenanceLogById(int id)
        {
            var maintenanceLog = await _service.GetMaintenanceLogByIdAsync(id);
            if (maintenanceLog == null)
            {
                return NotFound();
            }
            return Ok(maintenanceLog);
        }

        [HttpPost]
        public async Task<IActionResult> AddMaintenanceLog([FromBody] CreateMaintenanceLogDto maintenanceLogDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.AddMaintenanceLogAsync(maintenanceLogDto);
            return CreatedAtAction(nameof(GetMaintenanceLogById), new { id = maintenanceLogDto.AircraftRegistration }, maintenanceLogDto);
        }

        [HttpPut("{id}")]
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaintenanceLog(int id)
        {
            var maintenanceLog = await _service.GetMaintenanceLogByIdAsync(id);
            if (maintenanceLog == null)
            {
                return NotFound();
            }
            await _service.DeleteMaintenanceLogAsync(id);
            return NoContent();
        }
    }
}
