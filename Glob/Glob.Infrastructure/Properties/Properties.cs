using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Glob.Infrastructure.Services.IAesHandler;

namespace Glob.Infrastructure.Properties
{
    [Serializable]
    public class Properties : IProperties
    {
        public string Login { get; set; }
        public string PublickKey { get; set; }
        public string PrivateKey { get; set; }
        public string Password { get; set; }
        public Dictionary<string, AesKey> Keys { get; set; }

        public static IProperties Create()
        {
            return new Properties();
        }
    }
}
