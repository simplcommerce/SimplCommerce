using System;

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
                var message = $"partnerCode={PartnerCode}&accessKey={AccessKey}&requestId={RequestId}&amount={Amount}&orderId={OrderId}&orderInfo={OrderInfo}&returnUrl={ReturnUrl}&notifyUrl={NotifyUrl}&extraData={ExtraData}";
                return MomoSecurityHelper.HashSHA256(message, _secretKey);
            }
        }
    }
}
