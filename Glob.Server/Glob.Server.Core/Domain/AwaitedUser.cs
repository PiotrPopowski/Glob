using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Server.Core.Domain
{
    public class AwaitedUser
    {
        public Guid Id { get; protected set; }
        public string Contact { get; protected set; }
        public string SymmetricKey { get; protected set; }
        public string IV { get; protected set; }

        public AwaitedUser(string contact, string key, string iv)
        {
            Id = Guid.NewGuid();
            Contact = contact;
            SymmetricKey = key;
            IV = iv;
        }

        protected AwaitedUser()
        {
        }
    }
}
