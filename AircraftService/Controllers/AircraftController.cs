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
        private readonly IFuelManagementService _fuelManagementService;


        public AircraftController(IAircraftService aircraftService, IFuelManagementService fuelManagementService)
        {
            _aircraftService = aircraftService;
            _fuelManagementService = fuelManagementService;
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
        public async Task<IActionResult> GetAircraftById(string id)
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
        public async Task<IActionResult> UpdateAircraft(string id, [FromBody] UpdateAircraftDto updateAircraftDto)
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
        public async Task<IActionResult> DeleteAircraft(string id)
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

        //---------------------------------------FUel------------------

        //[HttpGet(Name = "all fuel data")]
        //public async Task<ActionResult<IEnumerable<FuelManagementDataDto>>> GetAllFuelManagementData()
        //{
        //    var fuelData = await _fuelManagementService.GetAllFuelManagementDataAsync();
        //    return Ok(fuelData);
        //}

        //[HttpGet(Name = "fuel by {id}")]
        //public async Task<ActionResult<FuelManagementDataDto>> GetFuelManagementDataById(int id)
        //{
        //    var fuelData = await _fuelManagementService.GetFuelManagementDataByIdAsync(id);
        //    if (fuelData == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(fuelData);
        //}

        //[HttpPost (Name = "Add fuel data")]
        //public async Task<ActionResult> AddFuelManagementData([FromBody] FuelManagementDataDto fuelManagementDataDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    await _fuelManagementService.AddFuelManagementDataAsync(fuelManagementDataDto);
        //    return CreatedAtAction(nameof(GetFuelManagementDataById), new { id = fuelManagementDataDto.AircraftId }, fuelManagementDataDto);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateFuelManagementData(int id, [FromBody] FuelManagementDataDto fuelManagementDataDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var existingFuelData = await _fuelManagementService.GetFuelManagementDataByIdAsync(id);
        //    if (existingFuelData == null)
        //    {
        //        return NotFound();
        //    }

        //    await _fuelManagementService.UpdateFuelManagementDataAsync(fuelManagementDataDto);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteFuelManagementData(int id)
        //{
        //    var existingFuelData = await _fuelManagementService.GetFuelManagementDataByIdAsync(id);
        //    if (existingFuelData == null)
        //    {
        //        return NotFound();
        //    }

        //    await _fuelManagementService.DeleteFuelManagementDataAsync(id);
        //    return NoContent();
        //}
    }
}
