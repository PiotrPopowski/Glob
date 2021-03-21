using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Glob.Infrastructure.Services.IRSAHandler;

namespace Glob.Infrastructure.Services
{
    public class RSAHandler : IRSAHandler
    {
        public string Decrypt(string data, string key)
        {
            using (var _RSA = new RSACryptoServiceProvider(2048))
            {
                try
                {
                    var bytesToDecrypt = Convert.FromBase64String(data);
                    _RSA.FromXmlString(key);
                    var decryptedBytes = _RSA.Decrypt(bytesToDecrypt, false);
                    var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedData.ToString();
                }
                finally
                {
                    _RSA.PersistKeyInCsp = false;
                }
            }
        }

        public string Encrypt(string data, string key)
        {
            using (var _RSA = new RSACryptoServiceProvider(2048))
            {
                try
                {
                    var bytesToEncrypt = Encoding.UTF8.GetBytes(data);
                    _RSA.FromXmlString(key);
                    var encryptedData = _RSA.Encrypt(bytesToEncrypt, false);
                    var base64Encrypted = Convert.ToBase64String(encryptedData);
                    return base64Encrypted;
                }
                finally
                {
                    _RSA.PersistKeyInCsp = false;
                }
            }
        }

        public byte[] SignData(string dataToSign, string key)
        {
            using (var RSAalg = new RSACryptoServiceProvider())
            {
                var dataBytes = Encoding.UTF8.GetBytes(dataToSign);
                RSAalg.FromXmlString(key);

                return RSAalg.SignData(dataBytes, SHA256.Create());
            }
        }
        public bool VerifySignature(string data, byte[] signature, string key)
        {
            using (var RSAalg = new RSACryptoServiceProvider())
            {
                var dataToVerify = Encoding.UTF8.GetBytes(data);
                RSAalg.FromXmlString(key);

                return RSAalg.VerifyData(dataToVerify, SHA256.Create(), signature);
            }
        }

        public RSAKeyPair GeneratePubPrivKeys()
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                var privateKey = getKeyString(rsa.ExportParameters(true));
                var publicKey = getKeyString(rsa.ExportParameters(false));
                return new RSAKeyPair(publicKey, privateKey);
            }
        }

        private static string getKeyString(RSAParameters publicKey)
        {
            var stringWriter = new System.IO.StringWriter();
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            xmlSerializer.Serialize(stringWriter, publicKey);
            return stringWriter.ToString();
        }

    }
}
