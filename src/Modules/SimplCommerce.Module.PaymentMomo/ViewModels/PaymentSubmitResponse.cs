using System.Text;

namespace SimplCommerce.Module.PaymentMomo.ViewModels
{
    public class PaymentSubmitResponse
    {
        public string RequestId { get; set; }

        public string PayUrl { get; set; }

        public string ErrorCode { get; set; }

        public string OrderId { get; set; }

        public string Message { get; set; }

        public string LocalMessage { get; set; }

        public string RequestType { get; set; }

        public string Signature { get; set; }

        public bool Validate(string secretKey)
        {
            var sb = new StringBuilder();
            sb.Append($"requestId={RequestId}");
            sb.Append($"&orderId={OrderId}");
            sb.Append($"&message={Message}");
            sb.Append($"&localMessage={LocalMessage}");
            sb.Append($"&payUrl={PayUrl}");
            sb.Append($"&errorCode={ErrorCode}");
            sb.Append($"&requestType={RequestType}");
            var message = sb.ToString();
            var hashMessage = MomoSecurityHelper.HashSHA256(message, secretKey);
            return string.Equals(hashMessage, Signature);
        }
    }
}
