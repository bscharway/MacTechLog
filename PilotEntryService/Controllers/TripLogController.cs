using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PilotEntryService.Models.DTOs;
using PilotEntryService.Services.Interfaces;

namespace PilotEntryService.Controllers
{
    /// <summary>
    /// API Controller for managing trip logs.
    /// </summary>
    [ApiController]
    [Route("api/TripLog")]
    public class TripLogController : ControllerBase
    {
        private readonly ITripLogService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="TripLogController"/> class.
        /// </summary>
        /// <param name="service">The trip log service.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public TripLogController(ITripLogService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all trip logs.
        /// </summary>
        /// <returns>A list of all trip logs.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllTripLogs()
        {
            var tripLogs = await _service.GetAllTripLogsAsync();
            return Ok(tripLogs);
        }

        /// <summary>
        /// Gets a specific trip log by ID.
        /// </summary>
        /// <param name="id">The ID of the trip log.</param>
        /// <returns>The trip log with the specified ID.</returns>
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

        /// <summary>
        /// Creates a new trip log.
        /// </summary>
        /// <param name="tripLogDto">The DTO containing trip log information.</param>
        /// <returns>The created trip log.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateTripLog([FromBody] CreateTripLogDto tripLogDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.CreateTripLogAsync(tripLogDto);
            return CreatedAtAction(nameof(GetTripLogById), new { id = tripLogDto.AircraftRegistration }, tripLogDto);
        }

        /// <summary>
        /// Updates an existing trip log.
        /// </summary>
        /// <param name="id">The ID of the trip log to update.</param>
        /// <param name="tripLogDto">The DTO containing updated trip log information.</param>
        /// <returns>No content if the update is successful.</returns>
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

        /// <summary>
        /// Deletes a trip log by ID.
        /// </summary>
        /// <param name="id">The ID of the trip log to delete.</param>
        /// <returns>No content if the deletion is successful.</returns>
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
