using System;

namespace SimplCommerce.Module.PaymentBtcPayServer.Areas.PaymentBtcPayServer.ViewModels
{
    public class BTCPayCheckoutForm
    {
        public string PaymentButtonLabel { get; set; }
        public bool UseModal { get; set; }
        public Uri Server { get; set; }
    }
}
