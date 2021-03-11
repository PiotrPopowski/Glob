using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glob.Server.Api.Requests
{
    public class SignIn
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
