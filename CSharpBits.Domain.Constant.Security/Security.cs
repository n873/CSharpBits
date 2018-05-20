using System;
using System.Text;

namespace CSharpBits.Domain.Constant.Security
{
    public static class Security
    {
        //DO NOT CHANGE
        // Once changed and in use, do not change the value below again or you
        // won't be able to decrypt previously stored passwords.
        public static readonly string SecurityKey = "123456789!@#$%^&*()_+=-";
        public static readonly byte[] InitializationVector = { 0x11, 0x22, 0x33, 0x44, 0x55, 0xAA, 0xBB, 0xCC };
        public static readonly byte[] TemporaryKey = Encoding.UTF8.GetBytes(SecurityKey.Substring(0, 8));
    }
}
