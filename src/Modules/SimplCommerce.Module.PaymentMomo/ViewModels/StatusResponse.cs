using System.Text;

namespace SimplCommerce.Module.PaymentMomo.ViewModels
{
    public class StatusResponse
    {
        public string PartnerCode { get; set; }

        public string AccessKey { get; set; }

        public string RequestId { get; set; }

        public string OrderId { get; set; }

        public string RequestType { get; set; }

        public string Amount { get; set; }

        public string TransId { get; set; }

        public string PayType { get; set; }

        public int ErrorCode { get; set; }

        public string Message { get; set; }

        public string LocalMessage { get; set; }

        public string ExtraData { get; set; }

        public string Signature { get; set; }

        public bool Validate(string secretKey)
        {
            var sb = new StringBuilder();
            sb.Append($"partnerCode={PartnerCode}");
            sb.Append($"&accessKey={AccessKey}");
            sb.Append($"&requestId={RequestId}");
            sb.Append($"&orderId={OrderId}");
            sb.Append($"&errorCode={ErrorCode}");
            sb.Append($"&transId={TransId}");
            sb.Append($"&amount={Amount}");
            sb.Append($"&message={Message}");
            sb.Append($"&localMessage={LocalMessage}");
            sb.Append($"&requestType={RequestType}");
            sb.Append($"&payType={PayType}");
            sb.Append($"&extraData={ExtraData}");
            var message = sb.ToString();
            var hashMessage = MomoSecurityHelper.HashSHA256(message, secretKey);
            return string.Equals(hashMessage, Signature);
        }
    }
}
