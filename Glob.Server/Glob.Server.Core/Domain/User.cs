using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Server.Core.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string PublicKey { get; set; }
        public HashSet<User> Contacts { get; protected set; } = new HashSet<User>();
        public HashSet<AwaitedUser> AwaitedContacts { get; protected set; } = new HashSet<AwaitedUser>();

        public User(string login, string firstName, string lastName, string passwordHash, string salt, string publicKey)
        {
            Id = Guid.NewGuid();
            Login = login;
            FirstName = firstName;
            LastName = lastName;
            PasswordHash = passwordHash;
            Salt = salt;
            PublicKey = publicKey;
        }
        protected User() { }
    }
}
