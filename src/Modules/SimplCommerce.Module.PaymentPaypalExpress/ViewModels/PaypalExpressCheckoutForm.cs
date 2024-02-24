using System;

namespace SimplCommerce.Module.PaymentPaypalExpress.ViewModels
{
    public class PaypalExpressCheckoutForm
    {
        public string Environment { get; set; }

        public decimal PaymentFee { get; set; }
        
        public Guid CheckoutId { get; set; }
    }
}
