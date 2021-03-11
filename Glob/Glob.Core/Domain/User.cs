using System;
using System.Collections.Generic;
using System.Text;

namespace Glob.Core.Domain
{
    public class User
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public List<Contact> Contacts { get; protected set; } = new List<Contact>();
        public IEnumerable<Contact> AwaitedContacts { get; protected set; } = new HashSet<Contact>();

        public User(string login, string firstName, string lastName, string password, string publicKey)
        {
            Login = login;
            FirstName = firstName;
            LastName = lastName;
            PublicKey = publicKey;
            Password = password;
        }

        protected User() { }
    }
}
