using DB;
using mcv_project2024.Migrations;
using mcv_project2024.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly UserService _userService;  // הזרקת השירות

    public UsersController(ApplicationDbContext context, UserService userService)
    {
        _context = context;
        _userService = userService;  // הזרקת השירות
    }

    // פונקציה ליצירת משתמש חדש
    [HttpPost("create_user")]
    public async Task<IActionResult> CreateUser([FromBody] User userDto)
    {
        if (userDto == null)
        {
            return BadRequest("Invalid data.");
        }

        var result = await _userService.CreateUserAsync(userDto);  // שימוש בשירות שהוזרק

        if (!result)
        {
            return BadRequest("User creation failed.");
        }

        return Ok("User created successfully.");
    }

    // פונקציה לאימות משתמש
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] User loginDto)
    {
        if (loginDto == null)
        {
            return BadRequest("Invalid login data.");
        }

        var user = await _userService.LoginAsync(loginDto.Email, loginDto.Password);  // שימוש בשירות שהוזרק

        if (user == null)
        {
            return Unauthorized("Invalid credentials.");
        }

        return Ok(user);
    }

    // פונקציה לעדכון פרטי משתמש
    [HttpPut("update_user_details")]
    public async Task<IActionResult> UpdateUserDetails([FromBody] User updateDto)
    {
        if (updateDto == null)
        {
            return BadRequest("Invalid update data.");
        }

        var result = await _userService.UpdateUserDetailsAsync(updateDto);  // שימוש בשירות שהוזרק

        if (!result)
        {
            return BadRequest("Update failed.");
        }

        return Ok("User updated successfully.");
    }

    // פונקציה להזמנת טיסה
    [HttpPost("book_flight")]
    public async Task<IActionResult> BookFlight([FromBody] Booking bookingDto)
    {
        if (bookingDto == null)
        {
            return BadRequest("Invalid booking data.");
        }

        var result = await _userService.BookFlightAsync(bookingDto.PassengerID, bookingDto.FlightId);  // שימוש בשירות שהוזרק

        if (!result)
        {
            return BadRequest("Flight booking failed.");
        }

        return Ok("Flight booked successfully.");
    }

     // פונקציה למחיקת לקוח
    [HttpDelete("delete_user/{userId}")]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        var result = await _userService.DeleteUserAsync(userId);

        if (!result)
        {
            return NotFound("User not found or deletion failed.");
        }

        return Ok("User deleted successfully.");
    }

    // פונקציה להצגת פרטי לקוח לפי מזהה
    [HttpGet("get_user/{userId}")]
    public async Task<IActionResult> GetUser(int userId)
    {
        var user = await _userService.GetUserByIdAsync(userId);

        if (user == null)
        {
            return NotFound("User not found.");
        }

        return Ok(user);
    }
    /*
    // פונקציה לרישום משתמש
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userDto)
    {
        if (userDto == null)
        {
            return BadRequest("Invalid data.");
        }

        var user = new User(0, userDto.FullName, user
        */
}