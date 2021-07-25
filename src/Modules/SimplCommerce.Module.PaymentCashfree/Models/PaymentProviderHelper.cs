using System;
using System.Security.Cryptography;
using System.Text;

namespace SimplCommerce.Module.PaymentCashfree.Models
{
    public static class PaymentProviderHelper
    {
        public static readonly string CashfreeProviderId = "Cashfree";

        public static string GetToken(string message, string secretKey)
        {
            var encoding = new ASCIIEncoding();
            var keyByte = encoding.GetBytes(secretKey);
            var messageBytes = encoding.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                var hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }
    }
}
