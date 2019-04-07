using System;
using System.Text;

namespace SimplCommerce.Module.PaymentMomo.ViewModels
{
    public class PaymentSubmitRequest
    {
        private string _secretKey;

        public PaymentSubmitRequest(string secretKey, string partnerCode, string accessKey, decimal amount, long orderId, string orderInfo, string returnUrl, string notifyUrl, string extraData)
        {
            _secretKey = secretKey;
            PartnerCode = partnerCode;
            AccessKey = accessKey;
            RequestId = orderId.ToString();
            Amount = Convert.ToInt64(amount).ToString();
            OrderId = orderId.ToString();
            OrderInfo = orderInfo;
            ReturnUrl = returnUrl;
            NotifyUrl = notifyUrl;
            ExtraData = extraData;
        }

        public string PartnerCode { get; private set; }

        public string AccessKey { get; private set; }

        public string RequestId { get; private set; }

        public string Amount { get; private set; }

        public string OrderId { get; private set; }

        public string OrderInfo { get; private set; }

        public string ReturnUrl { get; private set; }

        public string NotifyUrl { get; private set; }

        public string ExtraData { get; private set; }

        public string RequestType
        {
            get
            {
                return "captureMoMoWallet";
            }
        }

        public string Signature
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append($"partnerCode={PartnerCode}");
                sb.Append($"&accessKey={AccessKey}");
                sb.Append($"&requestId={RequestId}");
                sb.Append($"&amount={Amount}");
                sb.Append($"&orderId={OrderId}");
                sb.Append($"&orderInfo={OrderInfo}");
                sb.Append($"&returnUrl={ReturnUrl}");
                sb.Append($"&notifyUrl={NotifyUrl}");
                sb.Append($"&extraData={ExtraData}");
                var message = sb.ToString();
                return MomoSecurityHelper.HashSHA256(message, _secretKey);
            }
        }
    }
}
