public class User
{
    public int UserId { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }

    public User(int userId, string fullName, string email, string password, UserRole role)
    {
        UserId = userId;
        FullName = fullName;
        Email = email;
        Password = password;
        Role = role;
    }
}



