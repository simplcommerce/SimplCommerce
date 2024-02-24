using System;

namespace SimplCommerce.Module.PaymentMomo.ViewModels
{
    public class MomoCheckoutForm
    {
        public decimal PaymentFee { get; set; }

        public Guid CheckoutId { get; set; }
    }
}
