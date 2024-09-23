public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role{ get;set; }

        public User( string fullName, string email, string password,UserRole role)
        {
          
            FullName = fullName;
            Email = email;
            Password = password;
            Role = role;
        }


    public virtual Dictionary<string, object> GetUserInfo()
        {
            return new Dictionary<string, object>
            {
                { "id", UserId },
                { "full_name", FullName },
                { "email", Email }
            };
        }
    }

