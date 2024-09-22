using Microsoft.AspNetCore.Mvc;
using mcv_project2024.Models;

namespace mcv_project2024.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirplaneController : ControllerBase
    {
        private readonly AirplaneService _airplaneService;

        public AirplaneController(AirplaneService airplaneService)
        {
            _airplaneService = airplaneService; // Injecting the AirplaneService
        }

        // Create Airplane
        [HttpPost("create")]
        public async Task<IActionResult> CreateAirplane([FromBody] AirplaneDto airplaneDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newAirplane = new Airplane(airplaneDto.Manufacturer, airplaneDto.Nickname, airplaneDto.YearOfManufacture, airplaneDto.ImageUrl);
            var createdAirplane = await _airplaneService.AddAsync(newAirplane); // Using the service to add the airplane
            return CreatedAtAction(nameof(GetPlaneById), new { id = createdAirplane.Id }, createdAirplane); // Return 201 status with the new airplane's details
        }

        // Get Airplane by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlaneById(int id)
        {
            var airplane = await _airplaneService.GetByIdAsync(id);
            if (airplane == null)
                return NotFound($"Plane with ID {id} not found.");

            return Ok(airplane);
        }

        // Get all airplanes
        [HttpGet("all")]
        public async Task<IActionResult> GetAllPlanes()
        {
            var airplanes = await _airplaneService.GetAllAsync();
            return Ok(airplanes);
        }

        // Update airplane
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdatePlane(int id, [FromBody] AirplaneDto airplaneDto)
        {
            var updatedPlane = new Airplane(airplaneDto.Manufacturer, airplaneDto.Nickname, airplaneDto.YearOfManufacture, airplaneDto.ImageUrl);
            var airplane = await _airplaneService.UpdateAsync(id, updatedPlane);

            if (airplane == null)
                return NotFound($"Plane with ID {id} not found.");

            return Ok(airplane);
        }

        // Delete airplane
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePlane(int id)
        {
            var result = await _airplaneService.DeleteAsync(id);
            if (result)
                return Ok($"Plane with ID {id} deleted successfully.");

            return NotFound($"Plane with ID {id} not found.");
        }
    }

    // DTO for airplane data transfer
    public class AirplaneDto
    {
        public string Manufacturer { get; set; }
        public string Nickname { get; set; }
        public int YearOfManufacture { get; set; }
        public string ImageUrl { get; set; }
    }
}
