using System;

namespace SimplCommerce.Module.PaymentPaypalExpress.ViewModels
{
    public class PaymentExecuteVm
    {
        public string paymentID { get; set; }

        public string payerID { get; set; }

        public Guid CheckoutId { get; set; }
    }
}
