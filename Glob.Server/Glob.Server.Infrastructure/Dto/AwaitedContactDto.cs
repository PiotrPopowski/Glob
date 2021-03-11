using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Server.Infrastructure.Dto
{
    public class AwaitedContactDto
    {
        public string ContactName { get; set; }
        public string SymmetricKey { get; set; }
        public string IV { get; set; }
    }
}
