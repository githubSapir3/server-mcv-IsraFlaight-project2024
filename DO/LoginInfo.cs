namespace mcv_project2024.DO
{
    public class LoginInfo
    {
        public int UserId { get; set; }
        public string Password { get; set; }

        public LoginInfo(int userId, string password)
        {
            UserId = userId;
            Password = password;
        }
    }
}
