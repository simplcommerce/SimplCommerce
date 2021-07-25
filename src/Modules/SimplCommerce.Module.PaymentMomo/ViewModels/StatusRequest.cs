using System.Text;

namespace SimplCommerce.Module.PaymentMomo.ViewModels
{
    public class StatusRequest
    {
        private readonly string _secretKey;

        public StatusRequest(string secretKey, string partnerCode, string accessKey, long orderId)
        {
            _secretKey = secretKey;
            PartnerCode = partnerCode;
            AccessKey = accessKey;
            OrderId = orderId.ToString();
            RequestId = orderId.ToString();
        }

        public string PartnerCode { get; }

        public string AccessKey { get; }

        public string RequestId { get; }

        public string OrderId { get; }

        public string RequestType => "transactionStatus";

        public string Signature
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append($"partnerCode={PartnerCode}");
                sb.Append($"&accessKey={AccessKey}");
                sb.Append($"&requestId={RequestId}");
                sb.Append($"&orderId={OrderId}");
                sb.Append($"&requestType={RequestType}");
                var message = sb.ToString();
                return MomoSecurityHelper.HashSHA256(message, _secretKey);
            }
        }
    }
}
