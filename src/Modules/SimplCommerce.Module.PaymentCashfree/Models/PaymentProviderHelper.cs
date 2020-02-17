using System;
using System.Security.Cryptography;

namespace SimplCommerce.Module.PaymentCashfree.Models
{
    public static class PaymentProviderHelper
    {
        public static readonly string CashfreeProviderId = "Cashfree";

        public static string GetToken(string message, string secretKey)
        {
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secretKey);
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }
    }
}
