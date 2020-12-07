using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ETL_Extract.Lib
{
    public static class Encryption
    {
        public static byte[] Encrypt(string plainText, byte[] Key, byte[] IV)
        {
            byte[] encrypted;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using MemoryStream msEncrypt = new MemoryStream();
                using CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(plainText);
                }
                encrypted = msEncrypt.ToArray();
            }

            return encrypted;
        }

        public static string Decrypt(byte[] cipherText, byte[] Key, byte[] IV)
        {
            string decrypted = null;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using MemoryStream msDecrypt = new MemoryStream(cipherText);
                using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                using StreamReader srDecrypt = new StreamReader(csDecrypt);
                decrypted = srDecrypt.ReadToEnd();
            }

            return decrypted;
        }
    }
}
