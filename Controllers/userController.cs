using DB;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UsersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userDto)
    {
        if (userDto == null)
        {
            return BadRequest("Invalid data.");
        }

         
    var user = new User(0, userDto.FullName, userDto.Email, userDto.Password);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(RegisterUser), new { id = user.Id }, user);
    }
}

// Models/UserRegistrationDto.cs
public class UserRegistrationDto
{
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}
