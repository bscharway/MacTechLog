using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PilotEntryService.Models.DTOs;
using PilotEntryService.Services.Interfaces;

namespace PilotEntryService.Controllers
{
    // API Controller
    [ApiController]
    [Route("api/[controller]")]
    public class TripLogController : ControllerBase
    {
        private readonly ITripLogService _service;
        private readonly IMapper _mapper;

        public TripLogController(ITripLogService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTripLogs()
        {
            var tripLogs = await _service.GetAllTripLogsAsync();
            return Ok(tripLogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTripLogById(int id)
        {
            var tripLog = await _service.GetTripLogByIdAsync(id);
            if (tripLog == null)
            {
                return NotFound();
            }
            return Ok(tripLog);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTripLog([FromBody] CreateTripLogDto tripLogDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.CreateTripLogAsync(tripLogDto);
            return CreatedAtAction(nameof(GetTripLogById), new { id = tripLogDto.FlightNumber }, tripLogDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTripLog(int id, [FromBody] CreateTripLogDto tripLogDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await _service.UpdateTripLogAsync(id, tripLogDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTripLog(int id)
        {
            var tripLog = await _service.GetTripLogByIdAsync(id);
            if (tripLog == null)
            {
                return NotFound();
            }
            await _service.DeleteTripLogAsync(id);
            return NoContent();
        }
    }
}
