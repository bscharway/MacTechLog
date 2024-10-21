using AircraftService.Models.DTOs;
using AircraftService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AircraftService.Controllers
{
    // Aircraft Controller
    [ApiController]
    [Route("api/[controller]")]
    public class AircraftController : ControllerBase
    {
        private readonly IAircraftService _aircraftService;

        public AircraftController(IAircraftService aircraftService)
        {
            _aircraftService = aircraftService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAircrafts()
        {
            var aircrafts = await _aircraftService.GetAllAircraftAsync();
            if (aircrafts == null || !aircrafts.Any())
            {
                return NoContent();
            }
            return Ok(aircrafts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAircraftById(int id)
        {
            var aircraft = await _aircraftService.GetAircraftByIdAsync(id);
            if (aircraft == null)
            {
                return NotFound(new { Message = $"Aircraft with ID {id} not found." });
            }
            return Ok(aircraft);
        }

        [HttpPost]
        public async Task<IActionResult> AddAircraft([FromBody] CreateAircraftDto createAircraftDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdAircraft = await _aircraftService.AddAircraftAsync(createAircraftDto);
            return CreatedAtAction(nameof(GetAircraftById), new { id = createdAircraft.Id }, createdAircraft);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAircraft(int id, [FromBody] UpdateAircraftDto updateAircraftDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _aircraftService.UpdateAircraftAsync(id, updateAircraftDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = $"Aircraft with ID {id} not found." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAircraft(int id)
        {
            try
            {
                await _aircraftService.DeleteAircraftAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = $"Aircraft with ID {id} not found." });
            }
        }
    }
}
