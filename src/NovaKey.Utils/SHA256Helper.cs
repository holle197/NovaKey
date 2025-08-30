using System.Security.Cryptography;
using System.Text;

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
