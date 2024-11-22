using AircraftService.Models.DTOs;
using AircraftService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AircraftService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelManagementController : ControllerBase
    {
        private readonly IFuelManagementService _fuelManagementService;

        public FuelManagementController(IFuelManagementService fuelManagementService)
        {
            _fuelManagementService = fuelManagementService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuelManagementDataDto>>> GetAllFuelManagementData()
        {
            var fuelData = await _fuelManagementService.GetAllFuelManagementDataAsync();
            return Ok(fuelData);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FuelManagementDataDto>> GetFuelManagementDataById(int id)
        {
            var fuelData = await _fuelManagementService.GetFuelManagementDataByIdAsync(id);
            if (fuelData == null)
            {
                return NotFound();
            }
            return Ok(fuelData);
        }

        [HttpPost]
        public async Task<ActionResult> AddFuelManagementData([FromBody] FuelManagementDataDto fuelManagementDataDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _fuelManagementService.AddFuelManagementDataAsync(fuelManagementDataDto);
            return CreatedAtAction(nameof(GetFuelManagementDataById), new { id = fuelManagementDataDto.AircraftId }, fuelManagementDataDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFuelManagementData(int id, [FromBody] FuelManagementDataDto fuelManagementDataDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            await _fuelManagementService.UpdateFuelManagementDataAsync(id, fuelManagementDataDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuelManagementData(int id)
        {
            var existingFuelData = await _fuelManagementService.GetFuelManagementDataByIdAsync(id);
            if (existingFuelData == null)
            {
                return NotFound();
            }

            await _fuelManagementService.DeleteFuelManagementDataAsync(id);
            return NoContent();
        }
    }
}
