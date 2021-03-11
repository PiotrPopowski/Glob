using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glob.Server.Api.Requests
{
    public class Register
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PublicKey { get; set; }
    }
}
