using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Infrastructure.Services
{
    public class CryptographyProvider : ICryptographyProvider
    {
        private readonly IEncrypter _encrypter;
        public IRSAHandler RSA { get; }
        public IAesHandler AES { get; }
        public CryptographyProvider(IAesHandler aesHandler, IRSAHandler rsaHandler)
        {
            _encrypter = new Encrypter();
            AES = aesHandler;
            RSA = rsaHandler;
        }
        public string GetHash(string value)
        {
            var salt = _encrypter.GetSalt(value);
            var hash = _encrypter.GetHash(value, salt);
            return hash;
        }
    }
}
