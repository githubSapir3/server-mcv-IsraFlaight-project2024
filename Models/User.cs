public class User
    {
    private int v;

    public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role{ get;set; }

        public User(int id, string fullName, string email, string password,UserRole role)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Password = password;
            Role = role;
        }

    public User(int v, string fullName, string email, string password)
    {
        this.v = v;
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

