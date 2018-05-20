using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CSharpBits.Common.Utility.Security
{
    public static class SecurityUtility
    {
        public static MemoryStream Encrypt(this MemoryStream memoryStream, string input)
        {
            try
            {
                var cryptoTransform = new DESCryptoServiceProvider()
                    .CreateEncryptor(Domain.Constant.Security.Security.TemporaryKey, Domain.Constant.Security.Security.InitializationVector);
                memoryStream.TransformStream(cryptoTransform, Encoding.UTF8.GetBytes(input));
                return memoryStream;
            }
            catch (Exception) { throw; }
        }

        public static MemoryStream Decrypt(this MemoryStream memoryStream, string input)
        {
            try
            {
                var cryptoTransform = new DESCryptoServiceProvider()
                    .CreateDecryptor(Domain.Constant.Security.Security.TemporaryKey, Domain.Constant.Security.Security.InitializationVector);
                memoryStream.TransformStream(cryptoTransform, Convert.FromBase64String(input));
                return memoryStream;
            }
            catch (Exception) { throw; }
        }

        private static CryptoStream TransformStream(this MemoryStream memoryStream
            , ICryptoTransform cryptoTransform
            , Byte[] textByteArray)
        {
            try
            {
                var cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);
                cryptoStream.Write(textByteArray, 0, textByteArray.Length);
                cryptoStream.FlushFinalBlock();
                return cryptoStream;
            }
            catch (Exception) { throw; }
        }
    }
}
