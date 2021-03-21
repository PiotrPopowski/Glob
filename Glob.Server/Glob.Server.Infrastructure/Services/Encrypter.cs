using System;
using System.Security.Cryptography;
using System.Text;

namespace Glob.Server.Infrastructure.Services
{
    public class Encrypter: IEncrypter
    {
        private static readonly int DeriveBytesIterationsCount = 10000;
        private static readonly int SaltSize = 40;

        public string GetSalt(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Can not generate salt from an empty value.", nameof(value));
            }

            var random = new Random();
            var saltBytes = new byte[SaltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        public string GetHash(string value, string salt)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Can not generate hash from an empty value.", nameof(value));
            }
            if (String.IsNullOrWhiteSpace(salt))
            {
                throw new ArgumentException("Can not use an empty salt from hashing value.", nameof(value));
            }

            var pbkdf2 = new Rfc2898DeriveBytes(value, GetBytes(salt), DeriveBytesIterationsCount);

            return Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));
        }

        public static bool VerifySignedData(string dataToVerify, byte[] signature, string key)
        {
            using (var RSAalg = new RSACryptoServiceProvider())
            {
                var dataBytes = Encoding.UTF8.GetBytes(dataToVerify);
                RSAalg.FromXmlString(key);
                return RSAalg.VerifyData(dataBytes, SHA256.Create(), signature);
            }
        }

        private static byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
        }
    }
}
