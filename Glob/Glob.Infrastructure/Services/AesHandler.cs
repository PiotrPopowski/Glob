using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Glob.Infrastructure.Services.IAesHandler;

namespace Glob.Infrastructure.Services
{
    public class AesHandler : IAesHandler
    {
        public AesKey CreateKey()
        {
            using (Aes aes = Aes.Create())
            {
                return new AesKey(Convert.ToBase64String(aes.Key), Convert.ToBase64String(aes.IV));
            }
        }

        public string Decrypt(string ciphertext, string key, string iv)
        {
            if (ciphertext == null || ciphertext.Length <= 0)
                throw new ArgumentNullException("Wrong argument cipherText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Wrong argument Key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("Wrong argument IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Convert.FromBase64String(key);
                aesAlg.IV = Convert.FromBase64String(iv);

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(ciphertext)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }

        public string Encrypt(string plaintext, string key, string iv)
        {
            if (plaintext == null || plaintext.Length <= 0)
                throw new ArgumentNullException("Wrong parameter plainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Wrong parameter Key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("Wrong parameter IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Convert.FromBase64String(key);
                aesAlg.IV = Convert.FromBase64String(iv);

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plaintext);
                        }
                        encrypted = msEncrypt.ToArray();
                        return Convert.ToBase64String(encrypted);
                    }
                }
            }
        }

    }
}
