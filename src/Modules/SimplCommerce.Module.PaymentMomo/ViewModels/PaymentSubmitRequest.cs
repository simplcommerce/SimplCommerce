using System;
using System.Text;

namespace SimplCommerce.Module.PaymentMomo.ViewModels
{
    public class PaymentSubmitRequest
    {
        private readonly string _secretKey;

        public PaymentSubmitRequest(string secretKey, string partnerCode, string accessKey, decimal amount,
            long orderId, string orderInfo, string returnUrl, string notifyUrl, string extraData)
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

        public string PartnerCode { get; }

        public string AccessKey { get; }

        public string RequestId { get; }

        public string Amount { get; }

        public string OrderId { get; }

        public string OrderInfo { get; }

        public string ReturnUrl { get; }

        public string NotifyUrl { get; }

        public string ExtraData { get; }

        public string RequestType => "captureMoMoWallet";

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
