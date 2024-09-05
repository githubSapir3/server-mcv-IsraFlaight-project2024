// Models/Admin.cs

using System.Collections.Generic;


    public class Admin : User
    {
        public string Role { get; set; }

        public Admin(int id, string fullName, string email, string password, string role)
            : base(id, fullName, email, password)
        {
            Role = role;
        }

        public override Dictionary<string, object> GetUserInfo()
        {
            var info = base.GetUserInfo();
            info["role"] = Role;
            return info;
        }
    }

