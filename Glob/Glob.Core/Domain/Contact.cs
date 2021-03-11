using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Core.Domain
{
    public class Contact
    {
        public string Login { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string PublicKey { get; protected set; }

        public Contact(string login, string firstName, string lastName, string publicKey)
        {
            Login = login;
            FirstName = firstName;
            LastName = lastName;
            PublicKey = publicKey;
        }

        protected Contact() { }
    }
}
