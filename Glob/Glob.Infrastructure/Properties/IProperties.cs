using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Glob.Infrastructure.Services.IAesHandler;

namespace Glob.Infrastructure.Properties
{
    public interface IProperties
    {
        string Login { get; set; }
        string PublickKey { get; set; }
        string PrivateKey { get; set; }
        string Password { get; set; }
        Dictionary<string, AesKey> Keys { get; set; }
    }
}
