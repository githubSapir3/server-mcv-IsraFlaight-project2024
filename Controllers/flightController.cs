using Microsoft.AspNetCore.Mvc;
using mcv_project2024.DAL;
using mcv_project2024.Services;
using System;
using System.Threading.Tasks;

namespace mcv_project2024.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly FlightService _flightService;
        private readonly BookingService _flightBookingService;

        public FlightsController(FlightService flightService, BookingService flightBookingService)
        {
            _flightService = flightService;
            _flightBookingService = flightBookingService;
        }

        // יצירת טיסה
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

                return CreatedAtAction(nameof(GetFlightById), new { id = newFlight.FlightId }, newFlight);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // קבלת רשימת כל הטיסות
        [HttpGet("all")]
        public async Task<IActionResult> GetFlightSchedule()
        {
            var flights = await _flightService.GetAllAsync();
            return Ok(flights);
        }


        // קבלת טיסה לפי מזהה
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlightById(int id)
        {
            var flight = await _flightService.GetByIdAsync(id);
            if (flight == null)
            {
                return NotFound($"Flight with ID {id} not found.");
            }

            return Ok(flight);
        }

        // עדכון פרטי טיסה
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateFlight(int id, [FromBody] Flight flight)
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

        // מחיקת טיסה
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var result = await _flightService.DeleteAsync(id);
            if (result)
            {
                return Ok($"Flight with ID {id} deleted successfully.");
            }
            return NotFound($"Flight with ID {id} not found.");
        }
    }
}
