using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Services
{
    public static class CryptoManager
    {
        /*private static readonly byte[] Key = Encoding.UTF8.GetBytes("Your16ByteKeyHere"); // Debe ser de 16, 24 o 32 bytes
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("Your16ByteIVHere");*/ // Debe ser de 16 bytes
        private static readonly byte[] Key = new byte[] {
            0x3F, 0xD5, 0xA2, 0x7E, 0x9B, 0xE8, 0xC2, 0x6A,
            0x3A, 0x4B, 0xD9, 0x5E, 0x57, 0xCF, 0x2A, 0xE6,
            0x6C, 0x5F, 0xAB, 0xB8, 0x22, 0xB3, 0x34, 0xA5,
            0xAD, 0x9E, 0x12, 0xD3, 0x8E, 0x7B, 0x44, 0xDC
        };

        private static readonly byte[] IV = new byte[] {
            0xC2, 0x8A, 0x1D, 0xF3, 0xB6, 0xD9, 0x6E, 0x5C,
            0x74, 0xF8, 0xD7, 0x3E, 0x4A, 0x6C, 0xEB, 0x7B
        };

        public static string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException(nameof(plainText));

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException(nameof(cipherText));

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        public static string HashPassword(string pPassword)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(pPassword));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string Hash(string pText)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(pText));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
