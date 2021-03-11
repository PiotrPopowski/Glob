using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Glob.Infrastructure.Services.AesHandler;

namespace Glob.Infrastructure.Services
{
    public interface IAesHandler
    {
        string Encrypt(string plaintext, string key, string iv);
        string Decrypt(string plaintext, string key, string iv);
        AesKey CreateKey();

        [Serializable]
        public class AesKey
        {
            public string Key { get; protected set; }
            public string IV { get; protected set; }

            public AesKey(string key, string iv)
            {
                Key = key;
                IV = iv;
            }
        }
    }
}
