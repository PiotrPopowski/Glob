using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Infrastructure.Services
{
    public interface IRSAHandler
    {
        RSAKeyPair GeneratePubPrivKeys();
        string Encrypt(string data, string key);
        string Decrypt(string data, string key);

        public class RSAKeyPair
        {
            public string PublicKey { get; protected set; }
            public string PrivateKey { get; protected set; }

            public RSAKeyPair(string pub, string priv)
            {
                PublicKey = pub;
                PrivateKey = priv;
            }
        }
    }
}
