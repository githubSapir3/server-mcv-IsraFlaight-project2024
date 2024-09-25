using Microsoft.AspNetCore.Mvc;
using mcv_project2024.Module.Services;
using System;
using System.Threading.Tasks;
using mcv_project2024.Module.DAL;

namespace mcv_project2024.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase, ICRUD<Flight>
    {
    
        private readonly FlightService _flightService;

        public FlightsController(FlightService flightService, BookingService flightBookingService)
        {
            _flightService = flightService;
        }

        // Creat flight
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Flight flight)
        {
            try
            {
                var newFlight = await _flightService.CreateAsync(
                    flight.DepartureLocation,
                    flight.ArrivalLocation,
                    flight.AirplaneId,
                    flight.DepartureTime,
                    flight.ArrivalTime
                );

                return CreatedAtAction(nameof(GetById), new { id = newFlight.FlightId }, newFlight);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // Get all flight
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var flights = await _flightService.GetAllAsync();
            return Ok(flights);
        }


        // Get Flight by ID
        [HttpGet("getBy/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var flight = await _flightService.GetByIdAsync(id);
            if (flight == null)
            {
                return NotFound($"Flight with ID {id} not found.");
            }

            return Ok(flight);
        }

        // Update flight
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Flight flight)
        {
            try
            {
                var updatedFlight = await _flightService.UpdateAsync(id, flight);
                if (updatedFlight != null)
                {
                    return Ok(updatedFlight);
                }
                return NotFound($"Flight with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

        // Delete flight
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _flightService.DeleteAsync(id);
            if (result)
            {
                return Ok($"Flight with ID {id} deleted successfully.");
            }
            return NotFound($"Flight with ID {id} not found.");
        }

        [HttpGet("landing-in-tlv")]
        public async Task<IActionResult> GetLandingFlightsInTLV([FromQuery] DateTime currentTime, [FromQuery] DateTime endTime)
        {
            var flights = await _flightService.GetLandingFlightsInTLVAsync(currentTime, endTime);
            return Ok(flights);
        }
    }
}
