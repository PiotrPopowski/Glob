using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glob.Server.Api.Requests
{
    public class NewContact
    {
        public string ContactName { get; set; }
        public string SymmetricKey { get; set; }
        public string IV { get; set; }
    }
}
