using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Server.Infrastructure.Dto
{
    public class JwtDto
    {
        public string Token { get; set; }
        public UserDto User { get; set; }
    }
}
