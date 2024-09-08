using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Services.Helper
{
    public static class AesEncryptionHelper
    {
        private static readonly byte[] Salt = Encoding.UTF8.GetBytes("your-salt-value-here"); // Salt value
        private const int Iterations = 10000; // Number of iterations for PBKDF2

        private static byte[] GenerateKey(string password)
        {
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, Salt, Iterations))
            {
                return rfc2898DeriveBytes.GetBytes(32); // 256 bits key
            }
        }

        public static string Encrypt(string plainText, string password)
        {
            byte[] Key = GenerateKey(password);
            byte[] IV = new byte[16]; // 128 bits IV
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(IV);
            }

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    byte[] encryptedContent = msEncrypt.ToArray();
                    byte[] result = new byte[IV.Length + encryptedContent.Length];
                    Buffer.BlockCopy(IV, 0, result, 0, IV.Length);
                    Buffer.BlockCopy(encryptedContent, 0, result, IV.Length, encryptedContent.Length);
                    return Convert.ToBase64String(result);
                }
            }
        }

        public static string Decrypt(string cipherText, string password)
        {
            byte[] fullCipher = Convert.FromBase64String(cipherText);
            byte[] IV = new byte[16];
            byte[] cipher = new byte[fullCipher.Length - IV.Length];

            Buffer.BlockCopy(fullCipher, 0, IV, 0, IV.Length);
            Buffer.BlockCopy(fullCipher, IV.Length, cipher, 0, cipher.Length);

            byte[] Key = GenerateKey(password);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipher))
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                {
                    return srDecrypt.ReadToEnd();
                }
            }
        }
    }
}