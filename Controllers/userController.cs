using DB;
using mcv_project2024.Migrations;
using mcv_project2024.Module.DAL;
using mcv_project2024.DO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;  // הזרקת השירות
 
    public UsersController(ApplicationDbContext context, UserService userService)
    {
        _userService = userService;   // הזרקת השירות
    }

    // פונקציה ליצירת משתמש חדש
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] User userDto)
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
    public async Task<IActionResult> Login([FromBody] LoginInfo loginDto)
    {
        if (loginDto == null)
        {
            return BadRequest("Invalid login data.");
        }

        var user = await _userService.LoginAsync(loginDto);  // שימוש בשירות שהוזרק

        if (user == null)
        {
            return Unauthorized("Invalid credentials.");
        }

        return Ok(user);
    }

    // פונקציה לעדכון פרטי משתמש
    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update( [FromBody] User updateDto)
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

    // פונקציה למחיקת לקוח
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete([FromBody] int id)
    {
        var result = await _userService.DeleteUserAsync(id);

        if (!result)
        {
            return NotFound("User not found or deletion failed.");
        }

        return Ok("User deleted successfully.");
    }

    // פונקציה להצגת פרטי לקוח לפי מזהה
    [HttpGet("getBy/{id}")]
public async Task<IActionResult> GetById(string id)
{
    // המרת ה-ID ל-int
    if (!int.TryParse(id, out int userId))
    {
        return BadRequest("Invalid ID format.");
    }

    var user = await _userService.GetUserByIdAsync(userId);

    if (user == null)
    {
        return NotFound("User not found.");
    }

    return Ok(user);
}

}