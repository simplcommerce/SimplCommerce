using System;
using System.Security.Cryptography;
using System.Text;

namespace SimplCommerce.Module.PaymentMomo
{
    public static class MomoSecurityHelper
    {
        public static string HashSHA256(string message, string key)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var messageBytes = Encoding.UTF8.GetBytes(message);

            using (var hmacsha256 = new HMACSHA256(keyBytes))
            {
                var hashMessage = hmacsha256.ComputeHash(messageBytes);
                var hex = BitConverter.ToString(hashMessage);
                hex = hex.Replace("-", "").ToLower();
                return hex;
            }
        }
    }
}
