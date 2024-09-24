using DB;
using mcv_project2024.DO;
using mcv_project2024.Module.DAL;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static UsersController;

public class UserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    // פונקציה ליצירת משתמש חדש
    public async Task<bool> CreateUserAsync(User userDto)
    {
        var user = new User(userDto.UserId, userDto.FullName, userDto.Email, userDto.Password, UserRole.Passenger); // נניח שתפקיד ברירת המחדל הוא 'User'


        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return true;
    }

    // פונקציה לאימות משתמש
    public async Task<User> LoginAsync(LoginInfo loginInfo)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == loginInfo.UserId && u.Password == loginInfo.Password);
#pragma warning disable CS8603 // Possible null reference return.
        return user;
#pragma warning restore CS8603 // Possible null reference return.
    }

    // פונקציה לעדכון פרטי משתמש
    public async Task<bool> UpdateUserDetailsAsync(User updateDto)
    {
        var user = await _context.Users.FindAsync(updateDto.UserId);

        if (user == null) return false;
        user.UserId = updateDto.UserId;
        user.FullName = updateDto.FullName;
        user.Email = updateDto.Email;
        user.Password = updateDto.Password;
        user.Role = updateDto.Role;

        await _context.SaveChangesAsync();
        return true;
    }

     // פונקציה למחיקת משתמש
    public async Task<bool> DeleteUserAsync(int userId)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user == null) return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return true;
    }

    // פונקציה להצגת פרטי משתמש לפי מזהה
    public async Task<User> GetUserByIdAsync(int userId)
    {
        return await _context.Users.FindAsync(userId);
    }


    
}
