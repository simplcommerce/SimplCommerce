using System.Text;

namespace SimplCommerce.Module.PaymentMomo.ViewModels
{
    public class PaymentSubmitResult
    {
        public string PartnerCode { get; set; }

        public string AccessKey { get; set; }

        public string RequestId { get; set; }

        public string Amount { get; set; }

        public string OrderId { get; set; }

        public string OrderInfo { get; set; }

        public string OrderType { get; set; }

        public string TransId { get; set; }

        public string Message { get; set; }

        public string LocalMessage { get; set; }

        public string ResponseTime { get; set; }

        public int ErrorCode { get; set; }

        public string PayType { get; set; }

        public string ExtraData { get; set; }

        public string Signature { get; set; }

        public bool Validate(string secretKey)
        {
            var builder = new StringBuilder();
            builder.Append($"partnerCode={PartnerCode}");
            builder.Append($"&accessKey={AccessKey}");
            builder.Append($"&requestId={RequestId}");
            builder.Append($"&amount={Amount}");
            builder.Append($"&orderId={OrderId}");
            builder.Append($"&orderInfo={OrderInfo}");
            builder.Append($"&orderType={OrderType}");
            builder.Append($"&transId={TransId}");
            builder.Append($"&message={Message}");
            builder.Append($"&localMessage={LocalMessage}");
            builder.Append($"&responseTime={ResponseTime}");
            builder.Append($"&errorCode={ErrorCode}");
            builder.Append($"&payType={PayType}");
            builder.Append($"&extraData={ExtraData}");
            var message = builder.ToString();
            var hashMessage = MomoSecurityHelper.HashSHA256(message, secretKey);
            return string.Equals(hashMessage, Signature);
        }
    }
}
