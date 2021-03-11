using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Server.Infrastructure.Services
{
    public interface IJwtHandler
    {
        string CreateToken(Guid userId, string login);
    }
}
