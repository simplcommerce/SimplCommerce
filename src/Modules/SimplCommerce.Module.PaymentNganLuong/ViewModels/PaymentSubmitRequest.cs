using System.Collections.Generic;
using System.Net.Http;

namespace SimplCommerce.Module.PaymentNganLuong.ViewModels
{
    public class PaymentSubmitRequest
    {
        public int MerchantId { get; set; }

        public string MerchantPassword { get; set; }

        public string Version
        {
            get
            {
                return "3.1";
            }
        }

        public string Function
        {
            get
            {
                return "SetExpressCheckout";
            }
        }

        public string ReceiverEmail { get; set; }

        public string OrderCode { get; set; }

        public int TotalAmount { get; set; }

        public string PaymentMethod { get; set; }

        public string BankCode { get; set; }

        public string ReturnUrl { get; set; }

        public string CancelUrl { get; set; }

        public string BuyerFullname { get; set; }

        public string BuyerEmail { get; set; }

        public string BuyerMobile { get; set; }

        public FormUrlEncodedContent MakePostContent()
        {
            var keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("merchant_id", MerchantId.ToString()));
            keyValues.Add(new KeyValuePair<string, string>("merchant_password", SecurityHelper.MD5Hash(MerchantPassword)));
            keyValues.Add(new KeyValuePair<string, string>("version", Version));
            keyValues.Add(new KeyValuePair<string, string>("function", Function));
            keyValues.Add(new KeyValuePair<string, string>("receiver_email", ReceiverEmail));
            keyValues.Add(new KeyValuePair<string, string>("order_code", OrderCode));
            keyValues.Add(new KeyValuePair<string, string>("total_amount", TotalAmount.ToString()));
            keyValues.Add(new KeyValuePair<string, string>("payment_method", PaymentMethod));
            keyValues.Add(new KeyValuePair<string, string>("bank_code", BankCode));
            keyValues.Add(new KeyValuePair<string, string>("return_url", ReturnUrl));
            keyValues.Add(new KeyValuePair<string, string>("cancel_url", CancelUrl));
            keyValues.Add(new KeyValuePair<string, string>("buyer_fullname", BuyerFullname));
            keyValues.Add(new KeyValuePair<string, string>("buyer_email", BuyerEmail));
            keyValues.Add(new KeyValuePair<string, string>("buyer_mobile", BuyerMobile));
            keyValues.Add(new KeyValuePair<string, string>("cur_code", "vnd"));
            return new FormUrlEncodedContent(keyValues);
        }
    }
}
