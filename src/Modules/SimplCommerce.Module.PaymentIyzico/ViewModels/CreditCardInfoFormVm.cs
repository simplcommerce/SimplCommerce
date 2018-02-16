using Iyzpay.NetCore.Model;

namespace SimplCommerce.Module.PaymentIyzico.ViewModels
{
    public class CreditCardInfoFormVm
    {
        public string CardHolderName { get; set; }

        public string CardNumber { get; set; }

        public int ExpiryMonth { get; set; }

        public int ExpiryYear { get; set; }

        public int Cvv { get; set; }

        public bool Is3DSecure { get; set; }
    }
}