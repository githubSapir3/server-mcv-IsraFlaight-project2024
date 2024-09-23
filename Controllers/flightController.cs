using Microsoft.AspNetCore.Mvc;
using mcv_project2024.Models;
using mcv_project2024.Models.Services;
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

        //יצירת טיסה
        [HttpPost("schedule")]
        public async Task<IActionResult> ScheduleFlight([FromBody] Flight flightScheduleDto)
        {
            try
            {
                var newFlight = await _flightService.CreateAsync(
                    flightScheduleDto.DepartureLocation,
                    flightScheduleDto.ArrivalLocation,
                    flightScheduleDto.AirplaneId,
                    flightScheduleDto.DepartureTime,
                    flightScheduleDto.ArrivalTime
                );

                return CreatedAtAction(nameof(GetFlightById), new { id = newFlight.FlightId }, newFlight);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // הזמנת טיסה
        [HttpPost("book")]
        public async Task<IActionResult> BookFlight([FromBody] Booking flightBookingDto)
        {
            try
            {
                var ticket = await _flightBookingService.CreateBookingAsync(flightBookingDto.PassengerID, flightBookingDto.FlightId);
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // לצורך בדיקת השבת קבל זמני טיסה
        [HttpGet("schedule")]
        public async Task<IActionResult> GetFlightSchedule()
        {
            var flights = await _flightService.GetAllAsync();
            return Ok(flights);
        }

        // Check if flight coincides with Shabbat
        [HttpGet("check-shabbat/{id}")]
        public async Task<IActionResult> CheckFlightOnShabbat(int id)
        {
            var flight = await _flightService.GetByIdAsync(id);
            if (flight == null)
            {
                return NotFound($"Flight with ID {id} not found.");
            }

            bool isOnShabbat = await CheckShabbat(flight.DepartureTime, flight.ArrivalTime);
            return Ok(new { FlightId = id, IsOnShabbat = isOnShabbat });
        }

        private async Task<bool> CheckShabbat(DateTime departureTime, DateTime arrivalTime)
        {
            // Call to HebCal API to check Shabbat times
            // Implement API call logic here
            return false; // Change this to actual logic based on HebCal API response
        }

        // מחזיר טיסה לפי מזהה
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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlight(int id, [FromBody] Flight flightScheduleDto)
        {
            try
            {
                var updatedFlight = await _flightService.UpdateAsync(id, flightScheduleDto);
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

                // Delete a flight
        [HttpDelete("{id}")]
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
