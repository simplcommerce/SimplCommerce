using System.Collections.Generic;
using System.Net.Http;

namespace SimplCommerce.Module.PaymentNganLuong.ViewModels
{
    public class PaymentStatusRequest
    {
        private readonly string _marchantPassword;

        public PaymentStatusRequest(int merchantId, string merchantPassword, string token)
        {
            MerchantId = merchantId;
            _marchantPassword = merchantPassword;
            Token = token;
        }

        public int MerchantId { get; }

        public string Checksum => SecurityHelper.MD5Hash($"{Token}|{_marchantPassword}");

        public string Token { get; }

        public FormUrlEncodedContent MakePostContent()
        {
            var keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("merchant_id", MerchantId.ToString()));
            keyValues.Add(new KeyValuePair<string, string>("token", Token));
            keyValues.Add(new KeyValuePair<string, string>("checksum", Checksum));
            return new FormUrlEncodedContent(keyValues);
        }
    }
}
