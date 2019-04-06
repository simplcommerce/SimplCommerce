using System;

namespace SimplCommerce.Module.PaymentBtcPayServer.Areas.PaymentBtcPayServer.ViewModels
{
    public class BTCPayCheckoutForm
    {
        public decimal Amount { get; set; }

        public string ISOCurrencyCode { get; set; }
        public Uri Server { get; set; }
    }
}
