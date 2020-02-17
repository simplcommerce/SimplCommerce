using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SimplCommerce.Module.PaymentMomo
{
    public static class MomoSecurityHelper
    {
        public static string HashSHA256(string message, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            using (var hmacsha256 = new HMACSHA256(keyBytes))
            {
                byte[] hashMessage = hmacsha256.ComputeHash(messageBytes);
                string hex = BitConverter.ToString(hashMessage);
                hex = hex.Replace("-", "").ToLower();
                return hex;
            }
        }
    }
}
