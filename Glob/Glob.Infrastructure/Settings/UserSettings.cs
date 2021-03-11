using Glob.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Glob.Infrastructure.Services.IAesHandler;

namespace Glob.Infrastructure.Settings
{
    public class UserSettings
    {
        public User User { get; set; }
        public Dictionary<string, AesKey> Keys { get; set; }
    }
}
