using System.Collections.Generic;

namespace SimplCommerce.Module.Payment.ViewModels
{
    public class CheckoutPaymentForm
    {
        public IList<PaymentProviderVm> PaymentProviders { get; set; } = new List<PaymentProviderVm>();
    }
}
