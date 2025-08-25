using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NovaKey.Utils
{
    public static class SHA256Helper
    {
        public static byte[] GenerateHash(string secret)
        {
            byte[] textAsBytes = Encoding.UTF8.GetBytes(secret);
            return SHA256.HashData(textAsBytes);
        }
    }
}
