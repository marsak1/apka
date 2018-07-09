using System;

namespace VoloteaUIAutomation.Utilities.Objects
{
    public sealed class User
    {
        private static User Recent;

        public String username { get; set; }
        public String password { get; set; }

        public User(String common)
        {
            this.username = common;
            this.password = common;
        }

        public User(String username, String password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
