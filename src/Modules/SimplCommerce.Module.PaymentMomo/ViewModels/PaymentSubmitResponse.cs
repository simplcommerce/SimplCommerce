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
            var message = $"requestId={RequestId}&orderId={OrderId}&message={Message}&localMessage={LocalMessage}&payUrl={PayUrl}&errorCode={ErrorCode}&requestType={RequestType}";
            var hashMessage = MomoSecurityHelper.HashSHA256(message, secretKey);
            return string.Equals(hashMessage, Signature);
        }
    }
}
