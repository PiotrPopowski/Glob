using Glob.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Infrastructure.Requests
{
    public class AddContactRequest: IRequest
    {
        public string ContactName { get; set; }
        public string SymmetricKey { get; set; }
        public string IV { get; set; }
    }
}
