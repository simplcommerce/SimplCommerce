using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.Module.PaymentPaystack.ViewModels
{
    public class PaymentSubmitRequest
    {
        private string _secretKey;

        public PaymentSubmitRequest(string secretKey, decimal amount, long orderId, string notifyUrl, string orderInfo, string returnUrl)
        {
            _secretKey = secretKey;
            RequestId = orderId.ToString();
            Amount = Convert.ToInt64(amount).ToString();
            OrderId = orderId.ToString();
            OrderInfo = orderInfo;
            ReturnUrl = returnUrl;
            NotifyUrl = notifyUrl;
        }

        public string RequestId { get; private set; }

        public string Amount { get; private set; }

        public string OrderId { get; private set; }

        public string OrderInfo { get; private set; }

        public string ReturnUrl { get; private set; }
        public string NotifyUrl { get; private set; }
    }
}
