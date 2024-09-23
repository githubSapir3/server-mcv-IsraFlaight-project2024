using Microsoft.AspNetCore.Mvc;
using mcv_project2024.DO;
using mcv_project2024.Module.DAL;

namespace mcv_project2024.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase , ICRUD<Booking>
    {
        private readonly BookingService _bookingService;

        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }


        // Create Booking
        [HttpPost("create")]
        public async Task<IActionResult> Create(int passengerId, int flightId)
        {
            try
            {
                var booking = await _bookingService.CreateAsync(passengerId, flightId);
                var addedBooking = await _bookingService.AddAsync(booking);
                return Ok(addedBooking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get Booking by ID
        [HttpGet("get by/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var booking = await _bookingService.GetByIdAsync(id);
            if (booking != null)
            {
                return Ok(booking);
            }
            return NotFound($"Booking with ID {id} not found.");
        }

        // Get all Booking
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var bookings = await _bookingService.GetAllAsync();
            return Ok(bookings);
        }

        // Update Booking
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Booking updatedBooking)
        {
            var booking = await _bookingService.UpdateAsync(id, updatedBooking);
            if (booking != null)
            {
                return Ok(booking);
            }
            return NotFound($"Booking with ID {id} not found.");
        }

        // Delete Booking
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bookingService.DeleteAsync(id);
            if (result)
            {
                return Ok($"Booking with ID {id} deleted successfully.");
            }
            return NotFound($"Booking with ID {id} not found.");
        }

    }




}
