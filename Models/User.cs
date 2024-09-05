public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(int id, string fullName, string email, string password )
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Password = password;
        }

        public virtual Dictionary<string, object> GetUserInfo()
        {
            return new Dictionary<string, object>
            {
                { "id", Id },
                { "full_name", FullName },
                { "email", Email }
            };
        }
    }

