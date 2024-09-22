using Microsoft.AspNetCore.Mvc;
using mcv_project2024.Models;

namespace mcv_project2024.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _bookingService;

        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

       
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateBooking(int passengerId, int flightId)
        {
            try
            {
                var booking = await _bookingService.CreateBookingAsync(passengerId, flightId);
                var addedBooking = await _bookingService.AddAsync(booking);
                return Ok(addedBooking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await _bookingService.GetByIdAsync(id);
            if (booking != null)
            {
                return Ok(booking);
            }
            return NotFound($"Booking with ID {id} not found.");
        }

       
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllAsync();
            return Ok(bookings);
        }

      
        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] Booking updatedBooking)
        {
            var booking = await _bookingService.UpdateAsync(id, updatedBooking);
            if (booking != null)
            {
                return Ok(booking);
            }
            return NotFound($"Booking with ID {id} not found.");
        }

        
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var result = await _bookingService.DeleteAsync(id);
            if (result)
            {
                return Ok($"Booking with ID {id} deleted successfully.");
            }
            return NotFound($"Booking with ID {id} not found.");
        }
    }

    public class BookingRegistrationDto
    {
        public int bookingID { get; set; } 
        public int passengerID { get; set; }
        public Flight flight { get; set; }
    }


}
