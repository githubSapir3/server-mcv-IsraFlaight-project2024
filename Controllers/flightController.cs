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
        [HttpPost("schedule")]
        public async Task<IActionResult> ScheduleFlight([FromBody] Flight flight)
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

        // הזמנת טיסה
        [HttpPost("book")]
        public async Task<IActionResult> BookFlight([FromBody] Booking booking)
        {
            try
            {
                var ticket = await _flightBookingService.CreateBookingAsync(booking.PassengerID, booking.FlightId);
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // קבלת רשימת טיסות
        [HttpGet("schedule")]
        public async Task<IActionResult> GetFlightSchedule()
        {
            var flights = await _flightService.GetAllAsync();
            return Ok(flights);
        }

        // בדיקת טיסה בשבת
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
            // כאן תתבצע קריאה ל-API של HebCal
            return false; // צריך לעדכן את הלוגיקה על סמך תגובת ה-API
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
        [HttpPut("{id}")]
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
