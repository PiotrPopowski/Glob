using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Infrastructure.Services
{
    public interface ICryptographyProvider
    {
        IRSAHandler RSA { get; }
        IAesHandler AES { get; }
        string GetHash(string value);
    }
}
