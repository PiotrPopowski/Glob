using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Server.Core.Domain
{
    public class AwaitedUser
    {
        public User User { get; protected set; }
        public string SymmetricKey { get; protected set; }
        public string IV { get; protected set; }

        public AwaitedUser(User user, string key, string iv)
        {
            User = user;
            SymmetricKey = key;
            IV = iv;
        }
    }
}
